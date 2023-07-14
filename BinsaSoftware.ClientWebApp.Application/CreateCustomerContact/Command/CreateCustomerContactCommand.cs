using MediatR;

namespace BinsaSoftware.ClientWebApp.Application.CreateCustomerContact.Command
{
    public class CreateCustomerContactCommand : IRequest
    { 
        public CreateCustomerContactCommand(int ClientId, string Names, string Phone, string Email)
        {
            clientId = ClientId;
            names = Names;
            phone = Phone;
            email = Email;
        }

        public int clientId { get; set; }
        public string names { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
