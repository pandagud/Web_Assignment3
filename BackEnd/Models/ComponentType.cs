using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Models
{
    public partial class ComponentType
    {
        //Taget direkte fra opgavebeskrivelsen

        //public ComponentType()
        //{
        //    Components = new List<Component>();
        //        . Categories = new List<Category>();
        //}
        //public long ComponentTypeId { get; set; }
        //public string ComponentName { get; set; }
        //public string ComponentInfo { get; set; }
        //public string Location { get; set; }
        //public ComponentTypeStatus Status { get; set; }
        //public string Datasheet { get; set; }
        //public string ImageUrl { get; set; }
        //public string Manufacturer { get; set; }
        //public string WikiLink { get; set; }
        //public string AdminComment { get; set; }
        //public virtual ESImage Image { get; set; }
        //public ICollection<Component> Components { get; protected set; }
        //public ICollection<Category> Categories { get; protected set; }


        public long ComponentTypeId { get; set; }
        public string ComponentName { get; set; }
        public string ComponentInfo { get; set; }
        public string Location { get; set; }
        //Er en enum
        //public ComponentTypeStatus Status { get; set; }
        public string Datasheet { get; set; }
        public string ImageUrl { get; set; }
        public string Manufacturer { get; set; }
        public string WikiLink { get; set; }
        public string AdminComment { get; set; }
        //hvorfor er den virtual????
        //public virtual ESImage Image { get; set; }



    }
}
