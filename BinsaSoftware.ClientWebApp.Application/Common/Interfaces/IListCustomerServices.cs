using BinsaSoftware.ClientWebApp.Application.ListCustomer.Command;

namespace BinsaSoftware.ClientWebApp.Application.Common.Interfaces
{
    public interface IListCustomerServices
    {
        Task<List<InformationCustomerDto>> GetListCustomerAsync();
        Task<List<DropListClientDto>> GetCustomerAsync();
    }
}
