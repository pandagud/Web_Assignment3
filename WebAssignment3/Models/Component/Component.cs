﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignment3.Models.Component
{
    public class Component
    {
        public long ComponentId { get; set; }
        public long ComponentTypeId { get; set; }
        public int ComponentNumber { get; set; }
        public string SerialNo { get; set; }
        public ComponentStatus Status { get; set; }
        public string AdminComment { get; set; }
        public string UserComment { get; set; }
        public long? CurrentLoanInformationId { get; set; }
    }
    public enum ComponentTypeStatus
    {
        Available,
        ReservedAdmin
    }
}
