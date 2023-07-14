using BinsaSoftware.ClientWebApp.Application.Common.Interfaces;
using BinsaSoftware.ClientWebApp.Application.CreateCustomer.Command;
using BinsaSoftware.ClientWebApp.Application.CreateCustomerContact.ListCustomerContact;
using BinsaSoftware.ClientWebApp.Application.DetailCustomer.Command;
using BinsaSoftware.ClientWebApp.Application.ListCustomer.Command;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BinsaSoftware.ClientWebApp.Ioc.ApplicationServiceRegistration
{
    public static class ApplicationServiceRegistrationIoc
    {
        public static IServiceCollection AddApplicationServiceRegistrationIoc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistrationIoc).Assembly));
            services.AddMediatR(d => d.RegisterServicesFromAssembly(typeof(CreateCustomerHandle).Assembly));
            services.AddTransient<IListCustomerServices, ListCustomerServices>();
            services.AddTransient<IDetailCustomerServices, DetailCustomerServices>();
            services.AddTransient<IListCustomerContactServices, ListCustomerContactServices>(); 
            return services;
        }
    }
}
