using BinsaSoftware.ClientWebApp.Application.CreateCustomerContact.ListCustomerContact;

namespace BinsaSoftware.ClientWebApp.Application.Common.Interfaces
{
    public interface IListCustomerContactServices
    {
        Task<List<ListCustomerContactDto>> GetCustomerContactAsync(int id);
    }
}
