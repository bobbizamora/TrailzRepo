using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trailz.Data;
using trailz.Models;

namespace trailz.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RouteTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RouteTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RouteType
        public async Task<IActionResult> Index()
        {
            return View(await _context.RouteTypes.ToListAsync());
        }

        // GET: RouteType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routeType = await _context.RouteTypes
                .FirstOrDefaultAsync(m => m.RouteTypeID == id);
            if (routeType == null)
            {
                return NotFound();
            }

            return View(routeType);
        }

        // GET: RouteType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RouteType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RouteTypeID,Name")] RouteType routeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(routeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(routeType);
        }

        // GET: RouteType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routeType = await _context.RouteTypes.FindAsync(id);
            if (routeType == null)
            {
                return NotFound();
            }
            return View(routeType);
        }

        // POST: RouteType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RouteTypeID,Name")] RouteType routeType)
        {
            if (id != routeType.RouteTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(routeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteTypeExists(routeType.RouteTypeID))
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
            return View(routeType);
        }

        // GET: RouteType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routeType = await _context.RouteTypes
                .FirstOrDefaultAsync(m => m.RouteTypeID == id);
            if (routeType == null)
            {
                return NotFound();
            }

            return View(routeType);
        }

        // POST: RouteType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var routeType = await _context.RouteTypes.FindAsync(id);
            _context.RouteTypes.Remove(routeType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RouteTypeExists(int id)
        {
            return _context.RouteTypes.Any(e => e.RouteTypeID == id);
        }
    }
}
