using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace trailz.Models
{
    public class RouteAttribute
    {

        public int RouteAttributeID { get; set; }
        public int AttributeTypeID { get; set; }
        public int RouteID { get; set; }

        //navigation properties
        public Route Route { get; set; }
        public AttributeType AttributeType { get; set; }


    }
}
