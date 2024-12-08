using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using GestionFastFood.Controllers;
using GestionFastFood.Models;
using GestionFastFood.Models.ViewModels;

namespace GestionFastFood.Controllers
{

    //Registro de usuarios.
    public class AccesoController : Controller
    {
        //modelo UserRegistrarViewModel
        private readonly RestauranteDbContext _context;
        private readonly ILogger _logger;
        public AccesoController(RestauranteDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

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
                var existingUser =_context.Users.SingleOrDefault(u => u.Correo == model.Correo);//buscar solucion
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
                try
                {
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Login", "Acceso");
                }
                catch (Exception ex)
                
                {
                   // ModelState.AddModelError("", "Ocurrió un error al registrar el usuario: " + ex.Message);

                    //return View(model);
                    throw;
                    
                }
             

                
            }

            return View(model);
        }
        

        public static string Hash(string contraseña)
        {
            using(var sha256 = System.Security.Cryptography.SHA256.Create())
            {
               
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
           
        }

        /*
          StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
         **/

        /*public IActionResult OtraPagina()
		{
			return RedirectToAction("Register", "OtroControlador");
		}*/




        // Acción para mostrar la vista de login
        public IActionResult LoginView()
        {
            return View();
        }

        // Acción POST para procesar el login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginView(LoginModel model)
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
                if (user.Rol == "Recepcion")
                {
                    return RedirectToAction("Reservas", "Recepcion");
                }

                // Si no tiene un rol válido, redirigir a una página de error
                return RedirectToAction("Index", "Home");
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

