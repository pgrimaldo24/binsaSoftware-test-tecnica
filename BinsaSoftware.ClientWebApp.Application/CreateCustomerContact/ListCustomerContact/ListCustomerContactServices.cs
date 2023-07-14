using BinsaSoftware.ClientWebApp.Application.Common.Interfaces;

namespace BinsaSoftware.ClientWebApp.Application.CreateCustomerContact.ListCustomerContact
{
    public class ListCustomerContactServices : IListCustomerContactServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListCustomerContactServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IUnitOfWork UnitOfWork => _unitOfWork;

        public async Task<List<ListCustomerContactDto>> GetCustomerContactAsync(int id)
        {
            var response = new List<ListCustomerContactDto>();
            var query = await UnitOfWork.CustomerContactQuery.GetCustomerContactsAsync(id); 
            query.ToList().ForEach(x =>
            {
                var customer = new ListCustomerContactDto
                {
                    clientId = x.IdCustomer,
                    names = x.Nombre.ToUpper().Trim(),
                    phone = x.Telefono.Trim(),
                    email = x.Email.ToUpper().Trim()
                };
                response.Add(customer);
            }); 
            return response; 
        }
    }
}
