using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BackEnd;
using JwtAuthenticationHelper.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Web_Assignment3.Controllers
{
    public class LoginController : Controller
    {
        private readonly IJwtTokenGenerator tokenGenerator;

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

        [Route("Login/CreateAdminLogin")]
        public async Task<IActionResult> CreateAdminLogin(LoginModel model)
        {
            try
            {



                //Create an object with userinfo about the participant.
                var userInfo = new UserInfo
                {
                    hasAdminRights = true,
                    hasUserRights = false,
                    userID = "" + 1
                };
                //Generates token with claims defined from the userinfo object.
                var accessTokenResult = tokenGenerator.GenerateAccessTokenWithClaimsPrincipal(
                    "TestName",
                    AddMyClaims(userInfo));
                await HttpContext.SignInAsync(accessTokenResult.ClaimsPrincipal,
                    accessTokenResult.AuthProperties);

                RedirectToAction("Index", "HomePage");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return View("AdminLogin");

        }
        private static IEnumerable<Claim> AddMyClaims(UserInfo userInfo)
        {
            var myClaims = new List<Claim> //Hvorfor Y/N i stedet for en bool? Skal det være string?
            {
                new Claim("HasAdminRights", userInfo.hasAdminRights ? "Y" : "N"),
                new Claim("HasResearcherRights", userInfo.hasUserRights ? "Y" : "N"),
                new Claim("userID", userInfo.userID)
            };

            return myClaims;
        }
    }
}