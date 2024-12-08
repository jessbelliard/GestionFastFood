using GestionFastFood.Models;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;

namespace GestionFastFood
{
    public class RestauranteDbContext :DbContext
    {
        public RestauranteDbContext(DbContextOptions<RestauranteDbContext> options) : base(options) { }

        public DbSet<User>Users { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<PedidoProducto> PedidoProductos { get; set; }
        public DbSet<Posicion> Posicion { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }


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

            modelBuilder.Entity<Posicion>().ToTable("Posicion");
            modelBuilder.Entity<Posicion>().HasKey(x => x.PosicionId);


        modelBuilder.Entity<Pedido>()
        .HasOne(p => p.Posicion)  // Relación uno-a-uno desde Pedido a Posicion
        .WithOne(p => p.Pedido)  // Relación inversa desde Posicion a Pedido
        .HasForeignKey<Posicion>(p => p.PedidoId); // Clave foránea en Posicion

            base.OnModelCreating(modelBuilder);
            /*modelBuilder.Entity<Reserva>().HasKey(r => r.ReservaId);
            modelBuilder.Entity<Mesa>().HasKey(m => m.MesaId);

            modelBuilder.Entity<Mesa>()
                .HasMany<Reserva>()
                .WithOne()
                .HasForeignKey(r => r.MesaId);*/
            /*modelBuilder.Entity<PedidoProducto>().ToTable("PedidoProducto");
            modelBuilder.Entity<PedidoProducto>().HasKey(x => x.);*/

        }

    }
}
