using MediatR;

namespace BinsaSoftware.ClientWebApp.Application.UpdateCustomer.Command
{
    public class UpdateCustomerCommand : IRequest
    {
        public UpdateCustomerCommand(int clientId, string nombre, string domicilio, string codigoPostal, string poblacion)
        {
            ClientId = clientId;
            Nombre = nombre;
            Domicilio = domicilio;
            CodigoPostal = codigoPostal;
            Poblacion = poblacion;
        }

        public int ClientId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Domicilio { get; set; } = null!;

        public string CodigoPostal { get; set; } = null!;

        public string Poblacion { get; set; } = null!;
    }
}
