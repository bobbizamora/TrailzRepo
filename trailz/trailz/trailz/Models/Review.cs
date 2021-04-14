using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace trailz.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public DateTime ReviewRequestDate { get; set; }
        public string Comments { get; set; }
        public int LoggedUserID { get; set; }
        public int RouteID { get; set; }

        //navigation properties
        public LoggedInUser LoggedInUser { get; set; }
        public Route Route { get; set; }

    }
}
