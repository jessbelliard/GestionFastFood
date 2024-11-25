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

        public IActionResult CrearReserva()
        {
            ViewBag.Mesas = new SelectList(_context.Mesas,"MesaId", "NumeroMesa");
            /*ViewBag.Mesas = _context.Mesas.ToList();*/
            /*var mesas = _context.Mesas.ToList();
            ViewBag.Mesas = new SelectList(mesas, "MesaId", "Estado");*/
            return View();
        }


        public IActionResult ListaReservas()
        {
            var reservas = _context.Reservas.ToList();
            return View(reservas);
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
                    CantidadPersonas = model.CantidadPersonas,    
                    Estado = model.Estado,
                    UsuarioID = model.UsuarioID
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
                Estado = reserva.Estado,
                CantidadPersonas = reserva.CantidadPersonas
            };
            ViewBag.Mesas = new SelectList(_context.Mesas, "MesaId", "NumeroMesa");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarReserva(int id, Reserva model)
        {
            if (ModelState.IsValid)
            {
                var reserva = _context.Reservas.Find(id);
                if (reserva == null) return NotFound();
                reserva.MesaId = model.MesaId;
                reserva.ClienteNombre = model.ClienteNombre;
                reserva.FechaReserva = model.FechaReserva;
                reserva.Estado = model.Estado;
                reserva.CantidadPersonas = model.CantidadPersonas;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
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
