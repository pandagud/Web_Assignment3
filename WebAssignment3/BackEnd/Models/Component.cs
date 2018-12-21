using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Models
{
    public partial class Component
    {
        //Taget direkte fra opgavebeskrivelsen

        //public long ComponentId { get; set; }
        //public long ComponentTypeId { get; set; }
        //public int ComponentNumber { get; set; }
        //public string SerialNo { get; set; }
        //public ComponentStatus Status { get; set; }
        //public string AdminComment { get; set; }
        //public string UserComment { get; set; }
        //public long? CurrentLoanInformationId { get; set; }


        public long ComponentId { get; set; }
        //public long ComponentTypeId { get; set; }
        public int ComponentNumber { get; set; }
        public string SerialNo { get; set; }
        //Er en enum
        public string Status { get; set; }
        public string AdminComment { get; set; }
        public string UserComment { get; set; }
        public long? CurrentLoanInformationId { get; set; }

        public int ComponentTypeId { get; set; }


    }
}
