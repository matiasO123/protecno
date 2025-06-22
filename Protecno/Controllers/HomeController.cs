using System.Diagnostics;
//using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
using Protecno.Models;
using Protecno.Services;

namespace Protecno.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public IActionResult Home(string username, string password)
        {
            UsuarioService usuarioService = new UsuarioService(_context);
            if (usuarioService.EsUsuario(username, password)) return View("Index2");

            return PhysicalFile(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "html", "login.html"),
                "text/html"
            );
        }

        [HttpGet]
        public IActionResult Home_sin_auth()
        {
            return View("Index2");
        }

        public IActionResult Reportes()
        {
            return View("Reportes");
        }
        public IActionResult Login()
        {
            return PhysicalFile(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "html", "login.html"),
                "text/html"
            );
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
