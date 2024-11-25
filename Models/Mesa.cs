using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using AspNetCore;
using GestionFastFood.Models;

namespace GestionFastFood.Models
{
    public class Mesa
    {
        [Key]
        public int MesaId { get; set; }
        public int NumeroPosiciones { get; set; }
        public string Estado { get; set; }
        public int NumeroMesa { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}

