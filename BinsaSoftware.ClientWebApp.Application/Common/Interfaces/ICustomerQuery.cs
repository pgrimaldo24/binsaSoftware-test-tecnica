using BinsaSoftware.ClientWebApp.Domain;

namespace BinsaSoftware.ClientWebApp.Application.Common.Interfaces
{
    public interface ICustomerQuery
    {
        Task<List<ClientEntity>> GetCustomerAsync();
        Task<ClientEntity> GetCustomerByIdAsync(int id);
    }
}
