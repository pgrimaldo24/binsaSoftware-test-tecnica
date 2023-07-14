using BinsaSoftware.ClientWebApp.Application.Common.Interfaces;
using BinsaSoftware.ClientWebApp.Domain;
using MediatR;

namespace BinsaSoftware.ClientWebApp.Application.DeleteCustomer.Command
{
    public class DeleteCustomerHandle : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerHandle(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        private IUnitOfWork UnitOfWork => _unitOfWork;

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var requestQuery = await UnitOfWork.CustomerQuery.GetCustomerByIdAsync(request.clientId); 
            UnitOfWork.Set<ClientEntity>().Attach(requestQuery);
            UnitOfWork.Set<ClientEntity>().Remove(requestQuery);
            UnitOfWork.SaveChanges();
        }
    }
}
