using Protecno.Models;
using System.Threading.Tasks;

namespace Protecno.Services
{
    public class UsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }
        public bool EsUsuario(string user, string password)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.user == user && u.password == password);
            if (usuario == null) {return false;}
            return true;
        }
    }
}
