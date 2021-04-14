using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using trailz.Areas.Identity.Data;

namespace trailz.Models
{
    public class LoggedInUser
    {
        public int LoggedInUserID { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<LoggedInUserRequest> LoggedInUserRequests{ get; set; }
        public ICollection<Route> Routes { get; set; }
        public ICollection<Review> Reviews { get; set; }

        //ForeignKey CustomUser
        public string UserID { get; set; }
        public CustomUser CustomUser { get; set; }
    }
}
