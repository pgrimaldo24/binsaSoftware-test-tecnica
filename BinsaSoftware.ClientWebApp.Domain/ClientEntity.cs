namespace BinsaSoftware.ClientWebApp.Domain
{
    public class ClientEntity
    {
        public int ClientId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Domicilio { get; set; } = null!;

        public string CodigoPostal { get; set; } = null!;

        public string Poblacion { get; set; } = null!;

        public string CreatedBy { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
         
    }
}
