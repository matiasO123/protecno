namespace Protecno.Models
{
    public class Empleado:Persona
    {
        public DateTime inicioActividad { get; set; }
        public string estado { get; set; }
        public Usuario usuario { get; set; }
    }
}
