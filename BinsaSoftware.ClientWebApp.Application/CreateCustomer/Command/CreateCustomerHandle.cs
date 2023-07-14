using BinsaSoftware.ClientWebApp.Application.Common.Interfaces;
using BinsaSoftware.ClientWebApp.Domain;
using MediatR;

namespace BinsaSoftware.ClientWebApp.Application.CreateCustomer.Command
{
    public class CreateCustomerHandle : IRequestHandler<CreateCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerHandle(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        private IUnitOfWork UnitOfWork => _unitOfWork;

        public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (ReferenceEquals(null, request))
                throw new Exception("An exception has been thrown, please try again");

            var requestQuery = new ClientEntity
            {
                Nombre = request.names.ToUpper().Trim(),
                Domicilio = request.homeAddress.ToUpper().Trim(),
                CodigoPostal = request.postalCode.ToString(),
                Poblacion = request.population.ToUpper().Trim()
            };

            UnitOfWork.Set<ClientEntity>().Add(requestQuery);
            UnitOfWork.SaveChanges(); 
        }
    }
}
