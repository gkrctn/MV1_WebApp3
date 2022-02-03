using ItServiceApp.Data;
using ItServiceApp.MapperProfiles;
using ItServiceApp.Models.Identity;
using ItServiceApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiceApp
{
    public class Startup

    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
            });

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;

                //Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = false;

                //User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnoprstuvwxysABCDEFGHÝJKLMNOPRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;

                //options.SignIn.RequireConfirmedEmail = true;

            }).AddEntityFrameworkStores<MyContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                //Cookie Settings 
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;

            });

            services.AddTransient<IEmailSender, EmailSender>(); // loose couping
            services.AddScoped<IPaymentService, IyzicoPaymentService>(); // loose couping
            //services.AddScoped<IPaymentService, GarantiPaymentServices>(); // loose couping
            services.AddAutoMapper(options =>
            {
                options.AddProfile(typeof(PeymentProfile));
                options.AddProfile<EntityProfile>();
            });
            services.AddControllersWithViews()
                .AddNewtonsoftJson(
                options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

                
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection(); //https - güvenli sertifika ile çalýþmasý için
            app.UseStaticFiles(); //wwwroot klasöründeki statik dosyalara eriþmek için
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
                RequestPath = new PathString("/vendor")
            });

            app.UseRouting(); //rooting mekanizmasý için

            app.UseAuthentication();// Login logout kullanabilmek için

            app.UseAuthorization(); //authorization attiribute kullanabilmek için

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    areaName: "Admin",
                    name: "Admin",
                    pattern: "Admin/{controller=Manage}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


                // default rooting nasýl olacaðýný belirtmek için  

            });
        }
    }
}
