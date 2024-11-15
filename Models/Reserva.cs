﻿using GestionFastFood.Models;
using System.ComponentModel.DataAnnotations;

namespace GestionFastFood.Models
{
    public class Reserva
    {
        [Key] public int Id { get; set; }
        public int ReservaId { get; set; }
        public int MesaId { get; set; }
        public string ClienteNombre { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Estado { get; set; }
        public int UsuarioID { get; set; }

        public virtual Mesa Mesa { get; set; }
        public virtual User Usuario { get; set; }
    }
}
