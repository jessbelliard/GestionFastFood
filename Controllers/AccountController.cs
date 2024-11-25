using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GestionFastFood;
using GestionFastFood.Models;
using static GestionFastFood.Models.LoginModel;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System;
using System.Linq;

namespace GestionFastFood.Controllers
{
	public class AccountController : Controller
	{
		private readonly RestauranteDbContext _context;

		// Constructor para inyectar el DbContext
		public AccountController(RestauranteDbContext context)
		{
			_context = context;
		}

		// Acción para mostrar la vista de login
		public IActionResult Login()
		{
			return View();
		}

		// Acción POST para procesar el login
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				// Verificar si el usuario existe y la contraseña es válida
				var hashedPassword = HashPassword(model.Contraseña);
				var user = _context.Users
					.SingleOrDefault(u => u.Correo == model.Correo && u.Contraseña == hashedPassword);

				if (user == null)
				{
					// Usuario o contraseña incorrectos
					ModelState.AddModelError("", "Usuario o contraseña incorrectos");
					return View(model);
				}

				// Manejo de autenticación según el rol del usuario
				if (user.Rol == "Administrador")
				{
					return RedirectToAction("Dashboard", "Admin");
				}
				else if (user.Rol == "Mesero")
				{
					return RedirectToAction("Pedidos", "Mesero");
				}
				else if (user.Rol == "Cajero")
				{
					return RedirectToAction("Facturas", "Caja");
				}

				// Si no tiene un rol válido, redirigir a una página de error
				return RedirectToAction("Error", "Home");
			}

			// Si el modelo no es válido, regresar a la vista con los errores
			return View(model);
		}

		// Método privado para encriptar contraseñas
		private string HashPassword(string contraseña)
		{
			
			using (var sha256 = System.Security.Cryptography.SHA256.Create())
			{
				var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
				return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
			}
		}
	}

    /*se encarga de gestionar la información de la cuenta del usuario, como:Actualizar contraseñas.
    Recuperación de contraseñas (por ejemplo, "Olvidé mi contraseña").
    Actualizar perfil personal(cambiar nombre, correo, etc.).
    Cambiar roles, si se permite desde la cuenta.*/









} 
