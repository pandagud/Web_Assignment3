using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationHelper.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace WebAssignment3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // retrieve the configured token params and establish a TokenValidationParameters object,
            // we are going to need this later.


            var validationParams = new TokenValidationParameters
            {
                ClockSkew = TimeSpan.Zero,

                ValidateAudience = true,
                ValidAudience = "Test", //Configuration["Token:Audience"],

                ValidateIssuer = true,
                ValidIssuer = "Test", //Configuration["Token:Issuer"],

                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Test1111123323uq2hhsjajsjajhgfjhfksaoaodjdndjxsajanja")),   //Configuration["Token:SigningKey"])),
                ValidateIssuerSigningKey = true,

                RequireExpirationTime = true,
                ValidateLifetime = true
            };

            services.AddJwtAuthenticationWithProtectedCookie(validationParams);
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequiresAdmin", policy => policy.RequireClaim("HasAdminRights", "Y"));
                options.AddPolicy("RequiresResearcher", policy => policy.RequireClaim("HasResearcherRights", "Y"));
                options.AddPolicy("RequiresParticipant", policy => policy.RequireClaim("HasParticipantRights", "Y"));

            });

            services.AddMemoryCache();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.Use(async (ctx, next) =>
            {
                await next();

                if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
                {
                    //Re-execute the request so the user gets the error page
                    string originalPath = ctx.Request.Path.Value;
                    ctx.Items["originalPath"] = originalPath;
                    ctx.Request.Path = "/error/404";
                    await next();
                }
            });

            app.UseStaticFiles();
            app.UseAuthentication();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=AdminLogin}/{id?}");
            });
        }
    }
}
