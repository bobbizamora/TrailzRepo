using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trailz.Areas.Identity.Data;
using trailz.Data;

namespace trailz.Controllers
{
    public class UserController : Controller
    {
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly UserManager<CustomUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserController(
            UserManager<CustomUser> userManager,
            SignInManager<CustomUser> signInManager,
            ApplicationDbContext context
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

    }
}
