namespace Protecno.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public DateTime fecha { get; set; }
        public decimal importe { get; set; }
        public string medioPago { get; set; }
        public Reparacion Reparacion { get; set; }
    }
}
