using AspNetCore;
using GestionFastFood.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GestionFastFood.Controllers
{
    public class MesasController : Controller
    {
        private readonly RestauranteDbContext _context;

        public MesasController(RestauranteDbContext context)
        {
            _context = context;
        }

        // GET: /Mesas/Index
        public async Task<IActionResult> Index()
        {
            var mesas = await _context.Mesas.ToListAsync();
            return View(mesas);
        }

        // POST: /Mesas/ActualizarEstado/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarEstado(int id, string nuevoEstado)
        {
            var mesa = await _context.Mesas.FindAsync(id);
            if (mesa != null)
            {
                mesa.Estado = nuevoEstado;
                _context.Entry(mesa).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");

        }
    }
}
