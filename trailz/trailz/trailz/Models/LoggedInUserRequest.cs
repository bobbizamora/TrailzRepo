using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace trailz.Models
{
    public class LoggedInUserRequest
    {
        public int LoggedInUserRequestID { get; set; }

        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; }
        public int LoggedInUserID { get; set; }
        public int RouteID { get; set; }


        //navigation properties
        public LoggedInUser LoggedInUser { get; set; }
        public Route Route { get; set; }
    }
}
