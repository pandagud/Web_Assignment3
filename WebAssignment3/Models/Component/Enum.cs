using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignment3.Models.Component
{ 
        public enum ComponentStatus
        {
            Available,
            ReservedLoaner,
            ReservedAdmin,
            Loaned,
            Defect,
            Trashed,
            Lost,
            NeverReturned
        }
    
}
