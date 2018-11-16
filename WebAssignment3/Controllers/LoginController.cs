using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BackEnd;
using AuthenticationHelper.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAssignment3.Models.AdminLogin;

namespace WebAssignment3.Controllers
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

        [AllowAnonymous]
        public async Task<IActionResult> CreateAdminLogin(LoginModel model)
        {
            try
            {



                var userInfo = new UserInfo
                {
                    hasAdminRights = true,
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