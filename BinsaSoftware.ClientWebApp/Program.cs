//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();
 
using BinsaSoftware.ClientWebApp.Configuration; 
using Microsoft.AspNetCore;

public static class Program
{
    public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

    public static IWebHostBuilder CreateHostBuilder(string[] args)
                  => WebHost.CreateDefaultBuilder(args)
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseStartup<Startup>()
                        .ConfigureAppConfiguration((ctx, config) =>
                        {
                            var filename = string.Empty;
                            var envName = ctx.HostingEnvironment.EnvironmentName;
                            filename = $"appsettings.{envName}.json";
                            config.AddJsonFile(filename, optional: true, reloadOnChange: true);
                        });
}