namespace Protecno.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        public Reparacion reparacion { get; set; }  
    }
}
