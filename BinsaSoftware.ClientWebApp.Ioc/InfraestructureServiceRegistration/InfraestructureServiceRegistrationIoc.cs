using BinsaSoftware.ClientWebApp.Application.Common.Interfaces;
using BinsaSoftware.ClientWebApp.Infraestructure.Extensions.Context;
using BinsaSoftware.ClientWebApp.Infraestructure.Feature.UnitOfWork;
using BinsaSoftware.ClientWebApp.Infraestructure.Queries.CreateCustomer;
using BinsaSoftware.ClientWebApp.Infraestructure.Queries.CustomerContact;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BinsaSoftware.ClientWebApp.Ioc.InfraestructureServiceRegistration
{
    public static class InfraestructureServiceRegistrationIoc
    {
        public static IServiceCollection AddInfraestructureServiceRegistrationIoc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(InfraestructureServiceRegistrationIoc).Assembly));
            services.AddScoped<DbContext, BinsaSoftwareContextConnection>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ICustomerQuery, CustomerQuery>(); 
            services.AddTransient<ICustomerContactQuery, CustomerContactQuery>();
            return services;
        }
    }
}
