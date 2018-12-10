using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BackEnd;
using AuthenticationHelper.Abstractions;
using BackEnd.Handlers;
using BackEnd.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAssignment3.Models.AdminLogin;

namespace WebAssignment3.Controllers
{
    public class LoginController : Controller
    {
        private readonly IJwtTokenGenerator tokenGenerator;
        private UserInfo userInfo;

        public LoginController(IJwtTokenGenerator tokenGenerator)
        {
            this.tokenGenerator = tokenGenerator;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminLogin()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> LoginAsAdmin(LoginModel model)
        {
            try
            {
                LoginHandler loginHandler = new LoginHandler(new bachelordbContext());
                var status = loginHandler.LoginAdmin(model.Email, model.Password);
                if (status.success)
                {
                    if (status.adminuser.IsAdmin)
                    {
                        //Create an object with userinfo about the user.
                        userInfo = new UserInfo
                        {
                            hasAdminRights = true,
                            hasParticipantRights = true,
                            hasResearcherRights = false,
                            userID = "" + status.adminuser.IdAdmin
                        };
                    }
                    else
                    {
                        //Create an object with userinfo about the user.
                        userInfo = new UserInfo
                        {
                            hasAdminRights = false,
                            hasParticipantRights = true,
                            hasResearcherRights = false,
                            userID = "" + status.adminuser.IdAdmin
                        };
                    }
                

                    //Generates token with claims defined from the userinfo object.
                    var accessTokenResult = tokenGenerator.GenerateAccessTokenWithClaimsPrincipal(
                        model.Email,
                        AddMyClaims(userInfo));
                    await HttpContext.SignInAsync(accessTokenResult.ClaimsPrincipal,
                        accessTokenResult.AuthProperties);

                    return RedirectToAction("Index", "HomePage");

                }
                else
                {
                    var err = status.errormessage;
                    if (err == "Wrong password")
                        this.ModelState.AddModelError("Password", err.ToString());
                    else
                    {
                        this.ModelState.AddModelError("Email", err.ToString());
                    }
                }

                return View("AdminLogin");



            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        

        }


       [AllowAnonymous]
        public async Task<IActionResult> RegisterResearcher(LoginModel model)
        {
            try
            {

                var userInfo = new UserInfo
                {
                    hasAdminRights = false,
                    hasResearcherRights = true,
                    hasParticipantRights = false,
                    userID = "" + 1,
                };


                //Generates token with claims defined from the userinfo object.
                var accessTokenResult = tokenGenerator.GenerateAccessTokenWithClaimsPrincipal(
                    model.Email,
                    AddMyClaims(userInfo));
                await HttpContext.SignInAsync(accessTokenResult.ClaimsPrincipal,
                    accessTokenResult.AuthProperties);

                return RedirectToAction("Index", "HomePage");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }

        [AllowAnonymous]
        [Route("LogoutResearcher")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("AdminLogin", "Login");
        }
        private static IEnumerable<Claim> AddMyClaims(UserInfo userInfo)
        {
            var myClaims = new List<Claim> //Hvorfor Y/N i stedet for en bool? Skal det være string?
            {
                new Claim("HasAdminRights", userInfo.hasAdminRights ? "Y" : "N"),
                new Claim("HasResearcherRights", userInfo.hasResearcherRights ? "Y" : "N"),
                new Claim("HasParticipantRights", userInfo.hasParticipantRights ? "Y" : "N"),
                new Claim("userID", userInfo.userID)
            };

            return myClaims;
        }
    }
}