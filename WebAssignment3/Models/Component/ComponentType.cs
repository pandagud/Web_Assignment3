using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAssignment3.Models.Component
{
    public class ComponentType
    {
        public ComponentType()
        {
            Components = new List<Component>();
            Categories = new List<BackEnd.Models.Category>();
        }
        public long ComponentTypeId { get; set; }
        public string ComponentName { get; set; }
        public string ComponentInfo { get; set; }
        public string Location { get; set; }
        public ComponentTypeStatus Status { get; set; }
        public string Datasheet { get; set; }
        public string ImageUrl { get; set; }
        public string Manufacturer { get; set; }
        public string WikiLink { get; set; }
        public string AdminComment { get; set; }
        public virtual ESImage.ESImage Image { get; set; }
        public ICollection<Component> Components { get; set; }
        public List<BackEnd.Models.Category> Categories { get; set; }

        public List<SelectListItem> cateList { get; set; }

        public string selectedCat { get; set; }

        public string selectedCat2 { get; set; }

    }

}
