using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using GestionFastFood.Controllers;
using GestionFastFood.Models;
using GestionFastFood.Models.ViewModels;

namespace GestionFastFood.Controllers
{

    //Procesos de inicio de sesión y registro de usuarios.
    public class AccesoController : Controller
    {
        //modelo UserRegistrarViewModel
        private readonly RestauranteDbContext _context;
       
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
                //Verificar porque le hace falta una instancia 
                var existingUser =_context.Users.SingleOrDefault(u => u.Correo == model.Correo);
                if(existingUser != null)
                {
                    ModelState.AddModelError("Email", "Este correo ya esta en uso");
                    return View(model);
                }


                //encriptar contrase;a
                var passwordHash = Hash(model.Contraseña);

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

		private static string Hash(string contraseña)
        {
            using(var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
           
        }

		public IActionResult OtraPagina()
		{
			return RedirectToAction("Register", "OtroControlador");
		}

	}
}
