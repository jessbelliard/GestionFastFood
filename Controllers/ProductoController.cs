using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
//using GestionFastFood.Data;
using GestionFastFood.Models;

namespace GestionFastFood.Controllers
{
    public class ProductoController : Controller
    {
        private readonly RestauranteDbContext _context;

        public ProductoController(RestauranteDbContext context)
        {
            _context = context;
        }

        // GET: /Producto/Crear
        public IActionResult CrearProducto()
        {
            return View();
        }

        // POST: /Producto/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearProducto(Producto producto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(producto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(ListarProducto));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al crear el producto: " + ex.Message);
                }
            }
            return View(producto);
        }

        // GET: /Producto/Listar
        public async Task<IActionResult> ListarProducto()
        {
            var productos = await _context.Productos
            .Include(p => p.Pedido)
            .Include(p => p.Posicion)
            .ToListAsync();
            return View(productos);
        }

        // GET: /Producto/Editar/{id}
        public async Task<IActionResult> EditarProducto(int? id)
        {
          
            var producto = await _context.Productos
            .Include(p => p.Pedido)
             .Include(p => p.Posicion)
             .FirstOrDefaultAsync(p => p.ProductoId == id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

      

        // POST: /Producto/Editar/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarProducto(int id, Producto producto)
        {
            if (id != producto.ProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(ListarProducto));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Error al actualizar el producto: " + ex.Message);
                }
            }
            return View(producto);
        }

        // GET: /Producto/Eliminar/{id}
        public async Task<IActionResult> EliminarProducto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Pedido)
                .Include(p => p.Posicion)
                .FirstOrDefaultAsync(p => p.ProductoId == id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: /Producto/Eliminar/{id}
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(ListarProducto));
        }
    }
}
