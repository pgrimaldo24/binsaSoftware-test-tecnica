namespace BinsaSoftware.ClientWebApp.Application.ListCustomer.Command
{
    public class ListCustomerDto
    {
        public List<InformationCustomerDto> informationCustomerDtos { get; set; }
    }

    public class InformationCustomerDto
    {
        public int clientId { get; set; }
        public string names { get; set; }
        public string homeAddress { get; set; }
        public int postalCode { get; set; }
        public string population { get; set; }
    }
}
