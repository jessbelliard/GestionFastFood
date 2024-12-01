using GestionFastFood.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace GestionFastFood.Controllers
{
    public class PosicionesController : Controller
    {
        private readonly RestauranteDbContext _context;

        public PosicionesController(RestauranteDbContext context)
        {
            _context = context;
        }

        // GET: /Posiciones/Index
        public async Task<IActionResult> CreatePosicion()
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
        public async Task<IActionResult> CreatePosicion(Posicion Posicion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Posicion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListarPosiciones));
            }
            return View(Posicion);
           

        }
        // Acción para listar las Posiciones
        public async Task<IActionResult> ListarPosiciones()
        {
            var Posiciones = _context.Posicion.ToList(); // Obtiene todas las Posiciones desde la base de datos
            return View(Posiciones); // Pasa las Posiciones a la vista
        }

        public async Task<IActionResult> ActualizarPosicion()
        {
            var Posiciones = await _context.Posicion.ToListAsync();
            return View(Posiciones);
        }
        // POST: /Posiciones/ActualizarEstado/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        async Task<IActionResult> ActualizarEstado(int id)
        {
            var Posicion = await _context.Posicion.FindAsync(id);
            if (Posicion != null)
            {
                _context.Entry(Posicion).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("CreatePosicion");

        }
    } }
