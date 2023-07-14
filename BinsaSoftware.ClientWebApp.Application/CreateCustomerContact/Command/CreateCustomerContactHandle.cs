using BinsaSoftware.ClientWebApp.Application.Common.Interfaces;
using BinsaSoftware.ClientWebApp.Domain;
using MediatR;

namespace BinsaSoftware.ClientWebApp.Application.CreateCustomerContact.Command
{
    public class CreateCustomerContactHandle : IRequestHandler<CreateCustomerContactCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerContactHandle(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        private IUnitOfWork UnitOfWork => _unitOfWork;

        public async Task Handle(CreateCustomerContactCommand request, CancellationToken cancellationToken)
        {
            if (ReferenceEquals(null, request))
                throw new Exception("An exception has been thrown, please try again");

            var requestQuery = new CustomerContactEntity
            {
                ClientId = request.clientId,
                Nombre = request.names.ToUpper().Trim(),
                Telefono = request.phone,
                Email = request.email.Trim()
            };

            UnitOfWork.Set<CustomerContactEntity>().Add(requestQuery);
            UnitOfWork.SaveChanges();
        }
    }
}
