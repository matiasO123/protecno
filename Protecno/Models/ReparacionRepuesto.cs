namespace Protecno.Models
{
    public class ReparacionRepuesto
    {
        public int ID { get; set; }
        public Reparacion Reparacion { get; set; }
        public Repuesto Repuesto { get; set; }
        public decimal precio { get; set;}
    }
}
