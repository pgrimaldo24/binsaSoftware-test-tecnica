using BinsaSoftware.ClientWebApp.CrossCutting.Settings;
using BinsaSoftware.ClientWebApp.Infraestructure.Extensions.Connection;
using BinsaSoftware.ClientWebApp.Ioc.ApplicationServiceRegistration;
using BinsaSoftware.ClientWebApp.Ioc.InfraestructureServiceRegistration;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace BinsaSoftware.ClientWebApp.Configuration
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public IServiceCollection Services { get; private set; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = _configuration.GetSection("AppSettings");
            services.AddControllers();

            services.Configure<AppSetting>(appSettings);
            services.AddSingleton(x => x.GetService<IOptions<AppSetting>>().Value);
            services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddSqlExtensionConnection(appSettings.Get<AppSetting>());
            services.AddApplicationServiceRegistrationIoc(_configuration);
            services.AddInfraestructureServiceRegistrationIoc(_configuration);

            services.AddMvc(option => option.EnableEndpointRouting = false).AddSessionStateTempDataProvider(); 
            services.AddOptions();
            services.AddControllersWithViews();  
            services.AddHttpContextAccessor();
            services.AddEndpointsApiExplorer(); 
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1800);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            }); 
            services.AddMemoryCache();         
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

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseMvcWithDefaultRoute(); 
            app.UseSession(); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Client}/{action=ListClientView}/{id?}");
            });
        }
    }
}
