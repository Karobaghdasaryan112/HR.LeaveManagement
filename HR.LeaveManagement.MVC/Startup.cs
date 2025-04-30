using Hanssens.Net;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Services;
using HR.LeaveManagement.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;

namespace HR.LeaveManagement.MVC
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration services)
        {
            Configuration = services;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

     
                services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = new PathString("/users/login"); 
                        options.Cookie.Name = "AuthCookie";
                        options.Cookie.SameSite = SameSiteMode.None; 
                        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; 
                        options.Cookie.HttpOnly = true; 
                        options.SlidingExpiration = true; 
                        options.ExpireTimeSpan = TimeSpan.FromDays(7); 
                    });
            
            services.AddHttpContextAccessor();
            services.AddHttpClient<IClient,Client>(cl => cl.BaseAddress = new Uri("https://localhost:7042"));
            services.AddSingleton<ILocalStorage,LocalStorage>();
            services.AddSingleton<ILocalStorageServices, LocalStorageService>();
            services.AddScoped<ILeaveTypeService, LeaveTypeService>();
            services.AddScoped<ILeaveRequestService, LeaveRequestService>();
            services.AddScoped<ILeaveAllocationService, LeaveAllocationService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.Lax; 
            });
            services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
