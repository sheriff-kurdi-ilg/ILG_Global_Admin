using ILG_Global.BussinessLogic.Abstraction.Services;
using ILG_Global.Web.Services;
using ILG_Global_Admin.BussinessLogic.Abstraction.Repositories;
using ILG_Global_Admin.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ILG_Global_Admin.BussinessLogic.Models;
using ILG_Global_Admin.BussinessLogic.Abstraction.Services;
using ILG_Global_Admin.BussinessLogic.Services;

namespace ILG_Global_Admin.Web
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

            services.AddIdentity<ApplicationUser, IdentityRole>
      (options =>
      {
          options.SignIn.RequireConfirmedAccount = true;
          options.Password.RequireUppercase = false;
          options.Password.RequireLowercase = false;
          options.SignIn.RequireConfirmedEmail = false;
          options.SignIn.RequireConfirmedPhoneNumber = false;
          options.SignIn.RequireConfirmedAccount = false;

      })
      .AddEntityFrameworkStores<ILG_GlobalContext>();


            services.AddDbContext<ILG_GlobalContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ISucessStoryDetailRepository, SucessStoryDetailRepository>();
            services.AddScoped<ISucessStoryMasterRepository, SucessStoryMasterRepository>();
            services.AddScoped<ISuccessStoryService, SuccessStoryService>();
            services.AddScoped<IOurServiceDetailRepository, OurServiceDetailRepository>();
            services.AddScoped<IOurServiceMasterRepository, OurServiceMasterRepository>();
            services.AddScoped<IOurServicesService, OurServicesService>();            
            services.AddScoped<IContactUsDetailRepository, ContactUsDetailRepository>();
            services.AddScoped<IContactUsMasterRepository, ContactUsMasterRepository>();
            services.AddScoped<IContactUsService, ContactUsService>();

            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddControllersWithViews();

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
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
