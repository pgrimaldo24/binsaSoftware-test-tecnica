using BinsaSoftware.ClientWebApp.Application.Common.Interfaces;
using MediatR;

namespace BinsaSoftware.ClientWebApp.Application.UpdateCustomer.Command
{
    public class UpdateCustomerHandle : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerHandle(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IUnitOfWork UnitOfWork => _unitOfWork;

        public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var requestQuery = await UnitOfWork.CustomerQuery.GetCustomerByIdAsync(request.ClientId);
            requestQuery.Nombre = request.Nombre;
            requestQuery.Domicilio = request.Domicilio;
            requestQuery.CodigoPostal = request.CodigoPostal;
            requestQuery.Poblacion = request.Poblacion;
            UnitOfWork.SaveChanges();
        }
    }
}
