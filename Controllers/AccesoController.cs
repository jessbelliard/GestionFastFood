using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using GestionFastFood.Controllers;
using GestionFastFood.Models;
using GestionFastFood.Models.ViewModels;

namespace GestionFastFood.Controllers
{
    public class AccesoController : Controller
    {
        private readonly RestauranteDbContext _context;

        public AccesoController(RestauranteDbContext context) 
        {

            _context = context;
        }
        //GET: /AUTH/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistrarViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Verificar
                var existingUser =_context.Users.SingleOrDefault(u => u.Correo == model.Correo);
                if(existingUser != null)
                {
                    ModelState.AddModelError("Email", "Este correo ya esta en uso");
                    return View(model);
                }


                //encriptar contrase;a
                var passwordHash = HashPassword(model.Contraseña);

                var user = new User
                {
                    Nombre = model.Nombre,
                    Correo = model.Correo,
                    Contraseña = passwordHash,
                    Rol = model.Rol
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login", "Acceso");
            }

            return View(model);
        }
        
        private string HashPassword(string contraseña)
        {
            using(var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
            throw new NotImplementedException();
        }

		public IActionResult OtraPagina()
		{
			return RedirectToAction("Register", "OtroControlador");
		}

	}
}
