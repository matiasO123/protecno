using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace Protecno.Models
{
    public class Factura
    {
        public int Id { get; set; }
        [ValidateNever]
        public Pago Pago { get; set; }
        public int pagoId { get; set; }
        public string detalle {  get; set; }
        public int nroFactura { get; set; }
    }
}
