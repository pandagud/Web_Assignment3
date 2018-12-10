using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignment3.Models.Component;

namespace WebAssignment3.Models.Category
{
    public class Category
    {
        public Category()
        {
            ComponentTypes = new List<ComponentType>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<ComponentType> ComponentTypes { get; protected set; }
    }
}
