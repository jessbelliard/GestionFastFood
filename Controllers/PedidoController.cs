using GestionFastFood.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GestionFastFood.Controllers
{
    public class PedidoController : Controller
    {

        private readonly RestauranteDbContext _context;
        public PedidoController(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult>Index()
        {
            var pedido = await _context.Pedidos
                .Include(p => p.Mesa)
                .Include(p => p.PedidoProductos)
                .ThenInclude(pp => pp.Producto)
                .OrderByDescending(p => p.PedidoID)
                .ToListAsync();

            return View(pedido);
        }

        /*public async Task<IActionResult> Detalle(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Mesa)
                .Include(p => p.PedidoProductos)
                .ThenInclude(pp => pp.Producto)
                .FirstOrDefaultAsync(m => m.PedidoID == id);

            if (pedido = await _context.Pedidos)
                .Include(p => pedido.Mesa)
                    .Include(p => p.PedidoProducto)
                    .ThenInclude(pp => pp.Producto)
                    .FirstOrDefaultAsync(m => m.PedidoID == id);

            if(pedido == null)
            {
                return NotFound();
            }

            var viewModel = null PedidoProductoViewModel;
            {
                PedidoID = pedido.PedidoID;
                MesaID = pedido.MesaID;
                NumeroMesa = pedido.Mesa?.NumeroMesa ?? 0;
                Posicion = pedido.Posicion;
                Estado = pedido.Estado;
                Productos = pedido.PedidoProductos.Select(pp => new PedidoProductoViewModel
                {
                    NombreProducto = pp.Producto?.Nombre ?? "",
                    Cantidad = pp.Cantidad,
                    PrecioUnitario = pp.Producto?.Precio ?? 0,
                    Subtotal = (pp.Producto?.Precio
                })




            };

        }*/
    }
}
