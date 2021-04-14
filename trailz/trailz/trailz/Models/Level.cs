using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trailz.Models
{
    public class Level
    {
        public int LevelID { get; set; }
        public string Name { get; set; }

        //navigation properties
        public ICollection<Route> Routes { get; set; }
    }
}
