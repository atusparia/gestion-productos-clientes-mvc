using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCProCli.Models.Response
{
    public class ClienteResponseV1
    {
        public int Id { get; set; }
        public string Nombre { get; set; }        
        public string Correo { get; set; }        
        public string Telefono { get; set; }        
        public DateTime FechaCreacion { get; set; }
    }
}
