using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trailz.Models;

namespace trailz.ViewModels
{
    public class ListRoutesViewModel
    {
        public List<Route> Routes { get; set; }
        public List<Level> Levels { get; set; }
        public List<RouteType> RouteTypes { get; set; }
        public string DepartureSearch { get; set; }
        public string ArrivalSearch { get; set; }
        public string NameSearch { get; set; }
    }
}
