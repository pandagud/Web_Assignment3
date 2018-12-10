using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackEnd.Models;

namespace BackEnd.Handlers
{
    public class LoginHandler
    {
        private bachelordbContext _context;

        public LoginHandler(bachelordbContext context)
        {
            _context = context;
        }
        public DbStatus LoginAdmin(string email, string password)
        {
            DbStatus status = new DbStatus();
            Admin Admin = _context.admin.FirstOrDefault(admin => admin.Email == email);
            if (Admin != null)
            {
                if (Admin.Password == password)
                {
                    //Successfull login
                    status.success = true;
                    status.adminuser = Admin;
                }
                else
                {
                    //Wrong password
                    status.errormessage = "Wrong password";
                }
            }
            else
            {
                //No participant with this email exists in database
                status.errormessage = "No user with this email exists";
            }

            return status;
        }
    }
}
