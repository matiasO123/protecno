namespace Protecno.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public Rol rol { get; set; }
    }
}
