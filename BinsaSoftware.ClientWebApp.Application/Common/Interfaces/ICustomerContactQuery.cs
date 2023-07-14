using BinsaSoftware.ClientWebApp.Domain;

namespace BinsaSoftware.ClientWebApp.Application.Common.Interfaces
{
    public interface ICustomerContactQuery
    {
        Task<List<CustomerContactEntity>> GetCustomerContactsAsync(int id);
        Task<CustomerContactEntity> GetCustomerContactAsync(int id);
    }
}
