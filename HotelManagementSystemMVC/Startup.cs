using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.RespositoryInterfaces;
using WenKaiTsai.HotelManagementSystem.ApplicationCore.ServiceInterfaces;
using WenKaiTsai.HotelManagementSystem.Infrastructure.Data;
using WenKaiTsai.HotelManagementSystem.Infrastructure.Mapper;
using WenKaiTsai.HotelManagementSystem.Infrastructure.Mapper.Interfaces;
using WenKaiTsai.HotelManagementSystem.Infrastructure.Repositories;
using WenKaiTsai.HotelManagementSystem.Infrastructure.Services;

namespace HotelManagementSystemMVC
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
            services.AddControllersWithViews();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ICurrentAdmin, CurrentAdmin>();
            services.AddScoped<ICustomerMapper, CustomerMapper>();
            services.AddScoped<IRoomMapper, RoomMapper>();
            services.AddScoped<IRoomTypeMapper, RoomTypeMapper>();
            services.AddScoped<IServiceMapper, ServiceMapper>();

            services.AddHttpContextAccessor();

            //Inject connection string to DbContext
            services.AddDbContext<HotelManagementSystemDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("HotelManagementSystemDbConnection"));
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "HotelManagementSystem";
                    options.ExpireTimeSpan = TimeSpan.FromHours(2);
                    options.LoginPath = "/Account/Login";  // if the cookie auth fails, go to this url
                });
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

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
