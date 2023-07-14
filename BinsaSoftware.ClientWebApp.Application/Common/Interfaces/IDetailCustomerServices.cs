using BinsaSoftware.ClientWebApp.Domain;

namespace BinsaSoftware.ClientWebApp.Application.Common.Interfaces
{
    public interface IDetailCustomerServices
    {
        Task<ClientEntity> GetDetailCustomerByIdAsync(int id);
    }
}
