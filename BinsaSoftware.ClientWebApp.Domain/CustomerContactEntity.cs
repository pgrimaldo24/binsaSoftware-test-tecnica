namespace BinsaSoftware.ClientWebApp.Domain
{
    public class CustomerContactEntity
    {
        public int IdCustomer { get; set; }

        public int ClientId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
         
    }
}
