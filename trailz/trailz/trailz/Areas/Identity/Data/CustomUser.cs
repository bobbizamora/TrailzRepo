using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trailz.Models;

namespace trailz.Areas.Identity.Data
{
    public class CustomUser : IdentityUser
    {
        [PersonalData]
        public LoggedInUser LoggedInUser { get; set; }
    }
}
