﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignment3.Models.Component
{
    public class ComponentType
    {
        public ComponentType()
        {
            Components = new List<Component>();
            Categories = new List<Category.Category>();
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
        public ICollection<Component> Components { get; protected set; }
        public ICollection<Category.Category> Categories { get; protected set; }
    }

}
