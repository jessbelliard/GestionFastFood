using GestionFastFood.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GestionFastFood.Controllers
{
    public class ReservaController: Controller
    {
        private readonly RestauranteDbContext _context;

        public ReservaController(RestauranteDbContext context)
        {
            _context = context;
        }   

        public IActionResult ListaReservas()
        {
            var reservas = _context.Reservas.ToList();
            return View(reservas);
        }

        public IActionResult CrearReserva()
        {
            ViewBag.Mesas = new SelectList(_context.Mesas, "MesaId", "NumeroMesa");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearReserva(Reserva model)
        {
            if (ModelState.IsValid)
            {
                var reserva = new Reserva
                {
                    MesaId = model.MesaId,
                    ClienteNombre = model.ClienteNombre,
                    FechaReserva = model.FechaReserva,
                    Estado = model.Estado
                };
                _context.Reservas.Add(reserva);
                _context.SaveChanges();
                return RedirectToAction("ListaReservas");
            }
            ViewBag.Mesas = new SelectList(_context.Mesas, "MesaId", "NumeroMesa");
            return View(model);
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
                Estado = reserva.Estado
            };
            ViewBag.Mesas = new SelectList(_context.Mesas, "MesaId", "NumeroMesa");
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
