using MediatR;

namespace BinsaSoftware.ClientWebApp.Application.DeleteCustomerContact.Command
{
    public class DeleteCustomerContactCommand : IRequest
    {
        public int customerContactId { get; set; }
    }
}
