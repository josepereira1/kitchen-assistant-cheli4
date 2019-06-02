using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cheli4.Models;
using cheli4.Models.Comercial;
using cheli4.Models.RecursosHumanos;
using cheli4.shared;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace cheli4
{
    public class Startup
    {

        String petroDESKTOP = "DESKTOP-ROCLB6Q";
        String zeDESKTOP = "DESKTOP-IH6ARM1";
        String marquinhosDESKTOP = "DESKTOP-JD99DBI";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=" + petroDESKTOP + ";Database=cheli4;Trusted_Connection=True;ConnectRetryCount=0";

            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connection));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/ClienteView/login/";

                });
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
        }
    }
}
