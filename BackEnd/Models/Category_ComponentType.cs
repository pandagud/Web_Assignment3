using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Models
{
    public partial class Category_ComponentType
    {

        public int Category_ComponentTypeId { get; set; }
        public int CategoryId { get; set; }
        public int ComponentTypeId { get; set; }
    }
}
