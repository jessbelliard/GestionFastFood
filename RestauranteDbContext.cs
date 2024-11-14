using GestionFastFood.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionFastFood
{
    public class RestauranteDbContext :DbContext
    {
        public RestauranteDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User>Users { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<PedidoProducto> PedidoProductos { get; set; }

    }
}
