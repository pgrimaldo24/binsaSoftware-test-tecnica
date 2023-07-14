using BinsaSoftware.ClientWebApp.Application.Common.Interfaces;
using BinsaSoftware.ClientWebApp.Domain;
using MediatR;

namespace BinsaSoftware.ClientWebApp.Application.DeleteCustomerContact.Command
{
    public class DeleteCustomerContactHandle : IRequestHandler<DeleteCustomerContactCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerContactHandle(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IUnitOfWork UnitOfWork => _unitOfWork;

        public async Task Handle(DeleteCustomerContactCommand request, CancellationToken cancellationToken)
        {
            var requestQuery = await UnitOfWork.CustomerContactQuery.GetCustomerContactAsync(request.customerContactId);
            UnitOfWork.Set<CustomerContactEntity>().Attach(requestQuery);
            UnitOfWork.Set<CustomerContactEntity>().Remove(requestQuery);
            UnitOfWork.SaveChanges();
        }
    }
}
