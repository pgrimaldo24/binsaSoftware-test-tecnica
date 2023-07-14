using MediatR;

namespace BinsaSoftware.ClientWebApp.Application.CreateCustomer.Command
{
    public class CreateCustomerCommand : IRequest
    { 
        public CreateCustomerCommand(string Names, string HomeAddress, int PostalCode, string Population)
        {
            names = Names;
            homeAddress = HomeAddress;
            postalCode = PostalCode;
            population = Population;
        }

        public string names { get; set; }
        public string homeAddress { get; set; }
        public int postalCode { get; set; }
        public string population { get; set; } 
    }
}
