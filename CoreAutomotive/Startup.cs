using CoreAutomotive.Models;
using CoreAutomotive.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreAutomotive
{

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<UserData, Role>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<AppDbContext>();

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //        .AddEntityFrameworkStores<AppDbContext>();
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IOpiniaRepository, OpiniaRepository>();
            services.AddTransient<IPictureRepository, PictureRepository>();
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<UserData> userManager)
        {
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            DbInitializer.SeedData(userManager);
            app.UseMvc(
                routes =>
                {
                    routes.MapRoute(
                    name: "DefaultRoute",
                    template: "{controller=Home}/{Action=Index}/{id?}");
                }
                );

        }
    }
}