using GestionFastFood.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GestionFastFood.Services;
using System.Security.Cryptography;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GestionFastFood.Controllers
{
    public class ReservaController : Controller
    {
        private readonly RestauranteDbContext _context;
        private readonly EmailService _emailService;


        public ReservaController(RestauranteDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        /*public async Task<IActionResult> Index()
        {
            var reservas = await _context.Reservas.Include(r => r.Mesa).ToListAsync();
            return View(reservas);
        }*/

        public async Task<IActionResult> CrearReserva()
        {
            try
            {
                var mesasDisponibles = await _context.Mesa
                .Where(m => m.Estado == "Disponible")
                .ToListAsync();

                if (!mesasDisponibles.Any())
                {
                    TempData["Error"] = "No hay mesas disponibles en este momento.";
                }

                ViewBag.Mesas = new SelectList(mesasDisponibles, "MesaId", "NumeroMesa");
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearReserva(Reserva model)

        {
            try
            {        //fechas actuales
                if (model.FechaReserva < DateTime.Now)
                {
                    ModelState.AddModelError("FechaReserva", "La fecha de la reserva no puede ser en el pasado.");
                }
                if (model.ReservaId == 0)
                {
                    var reserva = new Reserva
                    {
                        MesaId = model.MesaId,
                        ClienteNombre = model.ClienteNombre,
                        FechaReserva = model.FechaReserva,
                        CantidadPersonas = model.CantidadPersonas,
                        Estado = "Pendiente",
                        UsuarioID = model.UsuarioID
                    };
                    _context.Reservas.Add(reserva);


                    var mesa = await _context.Mesa.FindAsync(reserva.MesaId);
                    if (mesa != null)
                    {
                        mesa.Estado = "Reservada";
                        _context.Entry(mesa).State = EntityState.Modified;
                    }

                    await _context.SaveChangesAsync();


                    /*_context.SaveChanges();
                    var mesasDisponibles = await _context.Mesas
                 //.Where(m => m.Estado == "Disponible")
               .ToListAsync();

                    ViewBag.Mesas = new SelectList(_context.Mesas, "MesaId", "NumeroMesa");
                    var mesas = _context.Mesas.ToList();
                    if (mesas.Count == 0)
                    {
                        Console.WriteLine("No hay mesa disponibles");
                    }*/


                    /*var asunto = "Confirmación de Reserva - Gestión FastFood";
                    var mensaje = $@"
                        <h1>Reserva Confirmada</h1>
                        <p>Hola {model.ClienteNombre},</p>
                        <p>Tu reserva ha sido confirmada:</p>
                        <ul>
                            <li>Mesa: {model.MesaId}</li>
                            <li>Fecha: {model.FechaReserva:dd/MM/yyyy HH:mm}</li>
                            <li>Cantidad de Personas: {model.CantidadPersonas}</li>
                        </ul>
                        <p>Gracias por elegirnos.</p>";

                    await _emailService.EnviarCorreoAsync("correo_cliente@gmail.com", asunto, mensaje);*/
                    return RedirectToAction("ListaReservas");
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            ViewBag.Mesas = new SelectList(_context.Mesa, "MesaId", "NumeroMesa");
            return View(model);
        }
        public IActionResult ListaReservas()
        {
            var reservas = _context.Reservas.ToList();
            return View(reservas);
        }



        public IActionResult EditarReserva(int id)
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva == null) return NotFound();
            var model = new Reserva
            {
                MesaId = reserva.MesaId,
                ClienteNombre = reserva.ClienteNombre,
                FechaReserva = reserva.FechaReserva,
                Estado = reserva.Estado,
                CantidadPersonas = reserva.CantidadPersonas
            };
            ViewBag.Mesas = new SelectList(_context.Mesa, "MesaId", "NumeroMesa");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarReserva(int id, Reserva model)
        {
            if (model.FechaReserva < DateTime.Now)
            {
                ModelState.AddModelError("FechaReserva", "La fecha de la reserva no puede ser en el pasado.");
            }
            if (id != 0)
            {
                var reserva = _context.Reservas.Find(id);
                if (reserva == null) return NotFound();
                reserva.ReservaId = id;
                reserva.MesaId = model.MesaId;
                reserva.ClienteNombre = model.ClienteNombre;
                reserva.FechaReserva = model.FechaReserva;
                reserva.Estado = model.Estado;
                reserva.CantidadPersonas = model.CantidadPersonas;
                _context.SaveChanges();
                return RedirectToAction("ListaReservas");
            }
            ViewBag.Mesas = new SelectList(_context.Mesa, "MesaId", "NumeroMesa");
            return View(model);
        }
        public IActionResult BorrarReserva(int id)
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva == null) return NotFound();
            _context.Reservas.Remove(reserva);
            _context.SaveChanges();
            return RedirectToAction("ListaReservas");
        }
    }
}
