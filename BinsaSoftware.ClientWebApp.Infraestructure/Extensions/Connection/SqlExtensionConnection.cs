using BinsaSoftware.ClientWebApp.CrossCutting.Settings;
using BinsaSoftware.ClientWebApp.Infraestructure.Extensions.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BinsaSoftware.ClientWebApp.Infraestructure.Extensions.Connection
{
    public static class SqlExtensionConnection
    {
        public static IServiceCollection AddSqlExtensionConnection(this IServiceCollection services, AppSetting appSetting)
        {
            return services.AddDbContext<BinsaSoftwareContextConnection>(options => options.UseSqlServer(
               string.Format("Data Source={0};Initial Catalog={1};Trusted_Connection=True;TrustServerCertificate=True;",
                       appSetting.ConnectionStrings.DataSource,
                       appSetting.ConnectionStrings.Catalog)));  
        }
    }
}
