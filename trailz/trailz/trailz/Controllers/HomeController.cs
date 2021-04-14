using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using trailz.Data;
using trailz.Models;
using trailz.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace trailz.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            ListRoutesViewModel viewmodel = new ListRoutesViewModel();
            viewmodel.Routes = await _context.Routes.Include(b => b.Level).Include(r => r.RouteType).ToListAsync();
            return View(viewmodel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Team()
        {
            return View();
        }

        public IActionResult Links()
        {
            return View();
        }

        public IActionResult Support()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: Route filtered on Departure en Arrival location
        public async Task<IActionResult> Search(ListRoutesViewModel viewModel)
        {
            IQueryable<Route> queryableRoutes = _context.Routes.Include(x => x.LoggedInUser).Include(x => x.RouteType).Include(x => x.Level).AsQueryable();

            if (!string.IsNullOrEmpty(viewModel.NameSearch))
            {
                queryableRoutes = queryableRoutes.Where(k => k.RouteName.Contains(viewModel.NameSearch));
            }
            if (!string.IsNullOrEmpty(viewModel.DepartureSearch))
            {
                queryableRoutes = queryableRoutes.Where(k => k.Departure.Contains(viewModel.DepartureSearch));
            }
            if (!string.IsNullOrEmpty(viewModel.ArrivalSearch))
            {
                queryableRoutes = queryableRoutes.Where(k => k.Arrival.Contains(viewModel.ArrivalSearch));
            }
            viewModel.Routes = await queryableRoutes.ToListAsync();
  
            return View("Index", viewModel);
        }
    }
}
