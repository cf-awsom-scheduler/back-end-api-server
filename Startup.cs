///-------------------------------------------------------------------------------------------------
// file:	Startup.cs
//
// summary:	Implements the startup class.
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using awsomAPI.Models;

//Morgana - JWT Auth Functionality found here https://jasonwatmore.com/post/2019/01/08/aspnet-core-22-role-based-authorization-tutorial-with-example-api#app-settings-json.


///-------------------------------------------------------------------------------------------------
// namespace: awsomAPI
//
// summary:	.
///-------------------------------------------------------------------------------------------------

namespace awsomAPI
{
    public class Startup
    {
        private string _secret = null;

        public IConfiguration Configuration { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
        ///
        /// <param name="configuration">    The configuration. </param>
        ///-------------------------------------------------------------------------------------------------

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Configure services. </summary>
        ///
        /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
        ///
        /// <param name="services"> The services. </param>
        ///-------------------------------------------------------------------------------------------------
        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services)
        {
            _secret = Configuration["Secret"];
            byte[] _key = Encoding.ASCII.GetBytes(_secret);

            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<AwsomApiContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("ProductionConnection")));

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = true;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(_key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Configures. </summary>
        ///
        /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
        ///
        /// <param name="app">  The application. </param>
        /// <param name="env">  The environment. </param>
        ///-------------------------------------------------------------------------------------------------
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            app.UseCors(settings => settings.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        }
    }
}
