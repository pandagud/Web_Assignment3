using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Models
{
    public partial class Category
    {
        //Taget direkte fra opgavebeskrivelsen

        //public Category()
        //{
        //    ComponentTypes = new List<ComponentType>();
        //}
        //public int CategoryId { get; set; }
        //public string Name { get; set; }
        //public ICollection<ComponentType> ComponentTypes { get; protected set; }


        public int CategoryId { get; set; }
        public string Name { get; set; }


    }
}
