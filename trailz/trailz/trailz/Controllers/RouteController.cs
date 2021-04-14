using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trailz.Areas.Identity.Data;
using trailz.Data;
using trailz.Models;
using trailz.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace trailz.Controllers
{
    [Authorize]
    public class RouteController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CustomUser> _userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public RouteController(ApplicationDbContext context,
            UserManager<CustomUser> userManager,
            IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Route
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var loggedInUser = _context.LoggedInUsers.Where(loggedInUser => loggedInUser.UserID == userId).FirstOrDefault();
            var loggedInUserId = loggedInUser.LoggedInUserID;

            var applicationDbContext = _context.Routes.Include(r => r.Level).Include(r => r.LoggedInUser).Include(r => r.RouteType).Include(c => c.RouteAttributes).Where(x => x.LoggedInUserID == loggedInUserId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Route/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes
                .Include(r => r.Level)
                .Include(r => r.LoggedInUser)
                .Include(r => r.RouteType)
                .Include(r => r.RouteAttributes)
                .ThenInclude(r => r.AttributeType)
                .FirstOrDefaultAsync(m => m.RouteID == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // GET: Route/Create
        public IActionResult Create()
        {
            CreateRouteViewModel viewModel = new CreateRouteViewModel()
            {
                Route = new Route(),
                AttributeList = new SelectList(_context.AttributeTypes, "AttributeTypeID", "Name"),
                SelectedAttributes = new List<int>(),
                RouteType = new SelectList(_context.RouteTypes, "RouteTypeID", "Name"),
                Level = new SelectList(_context.Levels, "LevelID", "Name")
            };
            return View(viewModel);
        }

        // POST: Route/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRouteViewModel viewModel)
        {
            viewModel.Route.RouteDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(viewModel);
                string uniqueGPXFile = UploadGPX(viewModel);

                List<Models.RouteAttribute> newAtrributes = new List<Models.RouteAttribute>();
                foreach (var attributeID in viewModel.SelectedAttributes)
                {
                    newAtrributes.Add(new Models.RouteAttribute
                    {
                        AttributeTypeID = attributeID,
                        RouteID = viewModel.Route.RouteID
                    });
                }
                var CustomUserID = _userManager.GetUserId(User);// hexadecimaal
                LoggedInUser loggedInUser = await _context.LoggedInUsers.FirstOrDefaultAsync(x => x.UserID == CustomUserID);
                viewModel.Route.LoggedInUserID = loggedInUser.LoggedInUserID;
                viewModel.Route.Picture = uniqueFileName;
                viewModel.Route.GPXfile = uniqueGPXFile;
                _context.Add(viewModel.Route);
                await _context.SaveChangesAsync();

                Route route = await _context.Routes.Include(o => o.RouteAttributes)
                    .SingleOrDefaultAsync(x => x.RouteID == viewModel.Route.RouteID);

                route.RouteAttributes.AddRange(newAtrributes);
                _context.Update(route);
                await _context.SaveChangesAsync();
 
                return RedirectToAction(nameof(Index));
            }
            viewModel.RouteType = new SelectList(_context.RouteTypes, "RouteTypeID", "Name", viewModel.Route.RouteTypeID);
            viewModel.Level = new SelectList(_context.Levels, "LevelID", "Name", viewModel.Route.LevelID);
            
            return View(viewModel);
        }

        private string UploadGPX(CreateRouteViewModel viewModel)
        {
            string uniqueGPX = null;

            if (viewModel.GPXfile != null)
            {
                string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "Assets");
                uniqueGPX = viewModel.GPXfile.FileName;
                string filepath = Path.Combine(uploadFolder, uniqueGPX);
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    viewModel.Picture.CopyTo(fileStream);
                }
            }
            return uniqueGPX;
        }

        private string UploadedFile(CreateRouteViewModel viewModel)
        {
            string uniqueFileName = null;

            if (viewModel.Picture != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Assets");
                uniqueFileName = viewModel.Picture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    viewModel.Picture.CopyTo(fileStream);
                }
            }
            return uniqueFileName;

        }

        // GET: Route/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EditRouteViewModel viewModel = new EditRouteViewModel();
            viewModel.Route = await _context.Routes.FindAsync(id);
            if (viewModel.Route == null)
            {
                return NotFound();
            }
            viewModel.RouteType = new SelectList(_context.RouteTypes, "RouteTypeID", "Name", viewModel.Route.RouteTypeID);
            viewModel.Level = new SelectList(_context.Levels, "LevelID", "Name", viewModel.Route.LevelID);
            return View(viewModel);
        }

        // POST: Route/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditRouteViewModel viewModel)
        {
            var CustomUserID = _userManager.GetUserId(User);// hexadecimaal
            LoggedInUser loggedInUser = await _context.LoggedInUsers.FirstOrDefaultAsync(x => x.UserID == CustomUserID);
            viewModel.Route.LoggedInUserID = loggedInUser.LoggedInUserID;
            viewModel.Route.RouteDate = DateTime.Now;
            if (id != viewModel.Route.RouteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewModel.Route);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteExists(viewModel.Route.RouteID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            viewModel.RouteType = new SelectList(_context.RouteTypes, "RouteTypeID", "Name", viewModel.Route.RouteTypeID);
            viewModel.Level = new SelectList(_context.Levels, "LevelID", "Name", viewModel.Route.LevelID);

            return View(viewModel);
        }

        // GET: Route/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Routes
                .Include(r => r.Level)
                .Include(r => r.LoggedInUser)
                .Include(r => r.RouteType)
                .FirstOrDefaultAsync(m => m.RouteID == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // POST: Route/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var route = await _context.Routes.FindAsync(id);
            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RouteExists(int id)
        {
            return _context.Routes.Any(e => e.RouteID == id);
        }

        [HttpGet("download")]
        public async Task<IActionResult> GetGPXDownload( int id)
        {
            var route = await _context.Routes.FindAsync(id);
            var net = new System.Net.WebClient();
            var data = net.DownloadData("wwwroot\\Assets\\" + route.GPXfile);
            var content = new System.IO.MemoryStream(data);
            var contentType = "text/gpx";
            var fileName = "GPXfile.gpx";
            return File(content, contentType, fileName);
        }
    }
}
