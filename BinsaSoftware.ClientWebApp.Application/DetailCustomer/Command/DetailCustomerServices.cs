using BinsaSoftware.ClientWebApp.Application.Common.Interfaces;
using BinsaSoftware.ClientWebApp.Domain;

namespace BinsaSoftware.ClientWebApp.Application.DetailCustomer.Command
{
    public class DetailCustomerServices : IDetailCustomerServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailCustomerServices(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        private IUnitOfWork UnitOfWork => _unitOfWork;

        public async Task<ClientEntity> GetDetailCustomerByIdAsync(int id)
        {
            return await UnitOfWork.CustomerQuery.GetCustomerByIdAsync(id); 
        }
    }
}
