namespace Protecno.Models
{
    public class Reparacion
    {
        public int Id { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime fechaFinalizacion { get; set; }
        public string estadoReparacion { get; set; }
        public decimal precio { get; set; }
        public int productoID { get; set; }
        public Producto Producto { get; set; }
    }
}
