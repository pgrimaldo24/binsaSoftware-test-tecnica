using MediatR;

namespace BinsaSoftware.ClientWebApp.Application.DeleteCustomer.Command
{
    public class DeleteCustomerCommand : IRequest
    {
        public int clientId { get; set; }
    }
}
