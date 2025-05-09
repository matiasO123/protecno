namespace Protecno.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public Pago Pago { get; set; }
        public string detalle {  get; set; }
        public int nroFactura { get; set; }
    }
}
