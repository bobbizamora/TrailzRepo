using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using trailz.Models;

namespace trailz.ViewModels
{
    public class EditRouteViewModel
    {
        public Route Route { get; set; }
        public SelectList RouteType { get; set; }
        public SelectList Level { get; set; }
        public IFormFile Picture { get; set; }
        public IFormFile GPXfile { get; set; }
        public IEnumerable<SelectListItem> AttributeList { get; set; }
        public IEnumerable<int> SelectedAttributes { get; set; }
    }
}
