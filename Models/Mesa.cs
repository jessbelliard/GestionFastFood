using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
//using AspNetCore;
using GestionFastFood.Models;

namespace GestionFastFood.Models
{
    public class Mesa
    {
        [Key]
        public int MesaId { get; set; }
        public string Estado { get; set; }
        public int NumeroMesa { get; set; }

        /*[JsonIgnore]
        public virtual ICollection<Reserva> Reservas { get; set; }*/
    }
}

