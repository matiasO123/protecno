namespace Protecno.Models
{
    public class Repuesto
    {
        public string Id { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public Proveedor proveedor { get; set; }
    }
}
