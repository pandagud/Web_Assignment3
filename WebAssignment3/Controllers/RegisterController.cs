using BackEnd.Handlers;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using WebAssignment3.Models.AdminLogin;

namespace WebAssignment3.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterAdmin(RegisterModell model)
        {
            if (ModelState.IsValid)
            {
                RegisterHandler registerhandler = new RegisterHandler(new bachelordbContext());
                Admin admin = new Admin();
                admin.Email = model.Email;
                admin.Firstname = model.Firstname;
                admin.Lastname = model.Lastname;
                admin.Password = model.Password;
                admin.IsAdmin = true;
                registerhandler.RegisterAdmin(admin);
                return RedirectToAction("Index", "HomePage");
            }

            return Index();
        }
    }
}