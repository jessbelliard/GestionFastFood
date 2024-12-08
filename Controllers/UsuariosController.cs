using GestionFastFood.Models.ViewModels;
using GestionFastFood.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GestionFastFood.Controllers
{

    //Manejo exclusivo por el administrador para gestionar usuarios y roles.
    public class UsuariosController : Controller
    {
        private readonly RestauranteDbContext _context;

        public UsuariosController(RestauranteDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var usuarios = _context.Users.ToList();
            return View(usuarios);
        }

        public IActionResult CrearUser()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var nuevoUsuario = new User
                {
                    Nombre = model.Nombre,
                    Correo = model.Email,
                    Contraseña = model.Password,
                    Rol = model.Rol
                };
                _context.Users.Add(nuevoUsuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Editar(int id)
        {
            var usuario = _context.Users.Find(id);
            if (usuario == null) return NotFound();

            var model = new UserViewModel
            {
                Nombre = usuario.Nombre,
                Email = usuario.Correo,
                Rol = usuario.Rol
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = _context.Users.Find(id);
                if (usuario == null) return NotFound();

                usuario.Nombre = model.Nombre;
                usuario.Correo = model.Email;
                usuario.Rol = model.Rol;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Borrar(int id)
        {
            var usuario = _context.Users.Find(id);
            if (usuario == null) return NotFound();

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarBorrado(int id)
        {
            var usuario = _context.Users.Find(id);
            if (usuario == null) return NotFound();

            _context.Users.Remove(usuario);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
