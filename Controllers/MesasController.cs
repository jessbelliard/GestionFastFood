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
        public async Task<IActionResult> CreateMesa()
        {

            try
            {
                return View();

            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

       

        [HttpPost]
        public async Task<IActionResult> CreateMesa(Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListarMesas));
            }
            return View(mesa);
           

        }
        // Acción para listar las mesas
        public async Task<IActionResult> ListarMesas()
        {
            var mesas = _context.Mesa.ToList();
            return View(mesas);
        }

        public async Task<IActionResult> ActualizarMesa()
        {
            var mesas = await _context.Mesa.ToListAsync();
            return View(mesas);
        }
        // POST: /Mesas/ActualizarEstado/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        async Task<IActionResult> ActualizarEstado(int id, string nuevoEstado)
        {
            var mesa = await _context.Mesa.FindAsync(id);
            if (mesa != null)
            {
                mesa.Estado = nuevoEstado;
                _context.Entry(mesa).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("CreateMesa");

        }
    } }
