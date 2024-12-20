﻿// <auto-generated />
using System;
using GestionFastFood;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionFastFood.Migrations
{
    [DbContext(typeof(RestauranteDbContext))]
    partial class RestauranteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionFastFood.Models.Factura", b =>
                {
                    b.Property<int>("FacturaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacturaID"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Itbis")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PedidoID")
                        .HasColumnType("int");

                    b.Property<string>("TipoFactura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalConImpuestos")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("FacturaID");

                    b.HasIndex("PedidoID");

                    b.ToTable("Factura", (string)null);
                });

            modelBuilder.Entity("GestionFastFood.Models.Mesa", b =>
                {
                    b.Property<int>("MesaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MesaId"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroMesa")
                        .HasColumnType("int");

                    b.HasKey("MesaId");

                    b.ToTable("Mesa", (string)null);
                });

            modelBuilder.Entity("GestionFastFood.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PedidoID"));

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MesaID")
                        .HasColumnType("int");

                    b.Property<int>("PosicionId")
                        .HasColumnType("int");

                    b.HasKey("PedidoID");

                    b.HasIndex("MesaID");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("GestionFastFood.Models.PedidoProducto", b =>
                {
                    b.Property<int>("PedidoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PedidoID"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("PedidoID1")
                        .HasColumnType("int");

                    b.Property<int>("ProductoID")
                        .HasColumnType("int");

                    b.HasKey("PedidoID");

                    b.HasIndex("PedidoID1");

                    b.HasIndex("ProductoID");

                    b.ToTable("PedidoProductos");
                });

            modelBuilder.Entity("GestionFastFood.Models.Posicion", b =>
                {
                    b.Property<int>("PosicionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PosicionId"));

                    b.Property<int>("MesaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.HasKey("PosicionId");

                    b.HasIndex("MesaId");

                    b.HasIndex("PedidoId")
                        .IsUnique();

                    b.ToTable("Posicion", (string)null);
                });

            modelBuilder.Entity("GestionFastFood.Models.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("PosicionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductoId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("PosicionId");

                    b.ToTable("Producto", (string)null);
                });

            modelBuilder.Entity("GestionFastFood.Models.Reserva", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservaId"));

                    b.Property<int>("CantidadPersonas")
                        .HasColumnType("int");

                    b.Property<string>("ClienteNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaReserva")
                        .HasColumnType("datetime2");

                    b.Property<int>("MesaId")
                        .HasColumnType("int");

                    b.Property<int?>("UserUsuarioID")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("ReservaId");

                    b.HasIndex("MesaId");

                    b.HasIndex("UserUsuarioID");

                    b.ToTable("Reserva", (string)null);
                });

            modelBuilder.Entity("GestionFastFood.Models.User", b =>
                {
                    b.Property<int>("UsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioID"));

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioID");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("YourNamespace.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("GestionFastFood.Models.Factura", b =>
                {
                    b.HasOne("GestionFastFood.Models.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("GestionFastFood.Models.Pedido", b =>
                {
                    b.HasOne("GestionFastFood.Models.Mesa", "Mesa")
                        .WithMany()
                        .HasForeignKey("MesaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mesa");
                });

            modelBuilder.Entity("GestionFastFood.Models.PedidoProducto", b =>
                {
                    b.HasOne("GestionFastFood.Models.Pedido", "Pedido")
                        .WithMany("PedidoProductos")
                        .HasForeignKey("PedidoID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionFastFood.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("GestionFastFood.Models.Posicion", b =>
                {
                    b.HasOne("GestionFastFood.Models.Mesa", "Mesa")
                        .WithMany()
                        .HasForeignKey("MesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionFastFood.Models.Pedido", "Pedido")
                        .WithOne("Posicion")
                        .HasForeignKey("GestionFastFood.Models.Posicion", "PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mesa");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("GestionFastFood.Models.Producto", b =>
                {
                    b.HasOne("GestionFastFood.Models.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionFastFood.Models.Posicion", "Posicion")
                        .WithMany()
                        .HasForeignKey("PosicionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Posicion");
                });

            modelBuilder.Entity("GestionFastFood.Models.Reserva", b =>
                {
                    b.HasOne("GestionFastFood.Models.Mesa", "Mesa")
                        .WithMany()
                        .HasForeignKey("MesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionFastFood.Models.User", null)
                        .WithMany("Reservas")
                        .HasForeignKey("UserUsuarioID");

                    b.Navigation("Mesa");
                });

            modelBuilder.Entity("YourNamespace.Models.UserProfile", b =>
                {
                    b.HasOne("GestionFastFood.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GestionFastFood.Models.Pedido", b =>
                {
                    b.Navigation("PedidoProductos");

                    b.Navigation("Posicion")
                        .IsRequired();
                });

            modelBuilder.Entity("GestionFastFood.Models.User", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
