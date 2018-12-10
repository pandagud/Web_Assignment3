using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.Models;

namespace BackEnd
{
    public class DbStatus
    {
        public bool success { get; set; }

        public string errormessage { get; set; }

        public Admin adminuser { get; set; }
    }
}
