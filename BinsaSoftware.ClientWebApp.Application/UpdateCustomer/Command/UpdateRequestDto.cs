namespace BinsaSoftware.ClientWebApp.Application.UpdateCustomer.Command
{
    public class UpdateRequestDto
    {
        public int ClientId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Domicilio { get; set; } = null!;

        public string CodigoPostal { get; set; } = null!;

        public string Poblacion { get; set; } = null!;
    }
}
