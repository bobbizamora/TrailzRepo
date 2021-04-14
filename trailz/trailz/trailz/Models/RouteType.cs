using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace trailz.Models
{
    public class RouteType
    {
        public int RouteTypeID { get; set; }
        public string Name { get; set; }

        //navigation properties
        public ICollection<Route> Routes { get; set; }

    }
}
