using GestionFastFood.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionFastFood
{
    public class RestauranteDbContext :DbContext
    {
        public RestauranteDbContext(DbContextOptions<RestauranteDbContext> options) : base(options) { }

        public DbSet<User>Users { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<PedidoProducto> PedidoProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasKey(x => x.UsuarioID);

            modelBuilder.Entity<Mesa>().ToTable("Mesa");
            modelBuilder.Entity<Mesa>().HasKey(x => x.MesaId);

            modelBuilder.Entity<Producto>().ToTable("Producto");
            modelBuilder.Entity<Producto>().HasKey(x => x.ProductoId);

            modelBuilder.Entity<Pedido>().ToTable("Pedido");
            modelBuilder.Entity<Pedido>().HasKey(x => x.PedidoID);

            modelBuilder.Entity<Reserva>().ToTable("Reserva");
            modelBuilder.Entity<Reserva>().HasKey(x => x.ReservaId);

            modelBuilder.Entity<Factura>().ToTable("Factura");
            modelBuilder.Entity<Factura>().HasKey(x => x.FacturaID);

            /*modelBuilder.Entity<PedidoProducto>().ToTable("PedidoProducto");
            modelBuilder.Entity<PedidoProducto>().HasKey(x => x.);*/

        }

    }
}
