using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace trailz.Models
{
    public class AttributeType
    {
        public int AttributeTypeID { get; set; }
        public string Name { get; set; }

        public ICollection<RouteAttribute> RouteAttributes { get; set; }
    }
}
