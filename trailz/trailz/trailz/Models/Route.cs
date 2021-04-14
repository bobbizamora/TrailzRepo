using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace trailz.Models
{
    public class Route
    {
        public int RouteID { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime RouteDate { get; set; }
        [Display(Name = "Route Name")]
        public string RouteName { get; set; }
        public string Description { get; set; }

        [Display(Name = "Distance")]
        public float Distance { get; set; }

        [Display(Name = "Start")]
        public string Departure { get; set; }

        [Display(Name = "Arrival")]
        public string Arrival { get; set; }

        public string GPXfile { get; set; }
        public string Picture { get; set; }
        public string minElevation { get; set; }
        public string maxElevation { get; set; }
        public int LoggedInUserID { get; set; }


        [Display(Name = "Activity")]
        public int RouteTypeID { get; set; }

        [Display(Name = "Level")]
        public int LevelID { get; set; }
        
        //navigation properties
        public Level Level { get; set; }
        public RouteType RouteType { get; set; }
        public LoggedInUser LoggedInUser { get; set; }
        public ICollection<LoggedInUserRequest> LoggedInUserRequests { get; set; }
        public List<RouteAttribute> RouteAttributes { get; set; }

    }
}
