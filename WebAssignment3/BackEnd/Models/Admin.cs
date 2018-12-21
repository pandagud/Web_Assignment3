using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BackEnd.Models
{
    public partial class Admin
    {
        public int IdAdmin { get; set; }
        public string Email { get; set; }

        public string Firstname { get; set; }


        public string Lastname { get; set; }

        
        public string Password { get; set; }

     

        public bool IsAdmin { get; set; }
    }
}
