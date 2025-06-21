using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Protecno.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public DateTime aniofabricacion { get; set; }
        public string estado { get; set; }
        [ValidateNever]
        public Cliente cliente { get; set; }
        public int clienteId{ get; set; }

    }
}
