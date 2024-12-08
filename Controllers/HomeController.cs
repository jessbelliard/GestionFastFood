using GestionFastFood.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GestionFastFood.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

		public IActionResult LoginView()
		{
			return View();
		}
		public IActionResult Register()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListaReservas()
        {
           
            return View();
        }

        public IActionResult CrearReserva()
        {
           
            return View();
        }
        public IActionResult EditarReserva()
        {

            return View();
        }

        public IActionResult CreateMesa()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		public IActionResult OtraPagina()
		{
			return RedirectToAction("Register", "AccesoController");
		}

	}
}