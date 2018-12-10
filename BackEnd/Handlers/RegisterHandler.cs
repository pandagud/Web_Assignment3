using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.Handlers
{
    public class RegisterHandler
    {
        private bachelordbContext _context;

        public RegisterHandler(bachelordbContext context)
        {
            _context = context;
        }

        public bool RegisterAdmin(Admin adminstrator)
        {
            if (_context.admin.Any(admin => admin.Email == admin.Email))
            {
                //Email allready exists
                return false;
            }
            else
            {
                //Register participant
                _context.admin.Add(adminstrator);
                _context.SaveChanges();
                return true;
            }
        }

    }
}
