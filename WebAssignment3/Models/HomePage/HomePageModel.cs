using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignment3.Models.Component;

namespace WebAssignment3.Models.HomePage
{
    public class HomePageModel
    {
        public List<BackEnd.Models.Component> listcomponent { get; set; }
        public List<BackEnd.Models.ComponentType> listcomponenttypes { get; set; }
        public List<BackEnd.Models.Category> listcategory { get; set; }

        public List<BackEnd.Models.Category_ComponentType> CategoryComponent { get; set; }

    }
}
