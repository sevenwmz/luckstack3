using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _17bang
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
            services.AddRazorPages();

            services.AddMemoryCache();

            services.AddSession(option =>
            {
                option.Cookie = new Microsoft.AspNetCore.Http.CookieBuilder
                {
                    Name = Const.COOKIE_USER,
                    IsEssential = true,
                    //Expiration = new TimeSpan(30, 0, 0)
                };
                option.IdleTimeout = new TimeSpan(0, 10, 5);
            });

            services.AddMvc()
                .AddRazorPagesOptions(option =>
                {
                    option.Conventions
                        .AddPageRoute("/Article", "/Article/Page-{id:int}")
                        .AddPageRoute("/Problem", "/Problem/Page-{id:int}")
                        .AddPageRoute("/Suggest", "/Suggest/Page-{id:int}")
                        .AddPageRoute("/Message/Mine", "/Message/Mine/{id:int=1}/{opt?}")
                        .AddPageRoute("/Problem/Edit", "/Problem/Edit/{id:int}")
                        .AddPageRoute("/Article/Edit", "/Article/Edit/{id:int}")
                        ;
                })
                .AddMvcOptions(options =>
                {
                    options.Filters.Add(typeof(ContextPerRequest));
                    options.Filters.Add(new LogExceptionFilter());
                }).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
