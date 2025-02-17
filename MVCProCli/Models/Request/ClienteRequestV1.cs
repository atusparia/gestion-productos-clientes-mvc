namespace MVCProCli.Models.Request
{
    public class ClienteRequestV1
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string? Telefono { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
    }
}
