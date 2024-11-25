using GestionFastFood.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

       

        [HttpPost]
        public async Task<IActionResult> CreateMesa(Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mesa);
           

        }
        // Acción para listar las mesas
        public async Task<IActionResult> ListarMesas()
        {
            var mesas = _context.Mesas.ToList(); // Obtiene todas las mesas desde la base de datos
            return View(mesas); // Pasa las mesas a la vista
        }


        // POST: /Mesas/ActualizarEstado/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        async Task<IActionResult> ActualizarEstado(int id, string nuevoEstado)
        {
            var mesa = await _context.Mesas.FindAsync(id);
            if (mesa != null)
            {
                mesa.Estado = nuevoEstado;
                _context.Entry(mesa).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("CreateMesa");

        }
    } }
