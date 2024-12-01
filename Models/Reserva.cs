using GestionFastFood.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GestionFastFood.Models
{
    public class Reserva
    {
        [Key]
        public int ReservaId { get; set; }
        public int MesaId { get; set; }
        public required string ClienteNombre { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Estado { get; set; }
        [Required]
        [Range(1,20,ErrorMessage = "La cantidad de personas debe ser entre 1 y 20.")]
        public int CantidadPersonas { get; set; }
        public int UsuarioID { get; set; }

        //[JsonIgnore]
        //public virtual IList<Mesa> Mesa { get; set; }
        public virtual Mesa Mesa { get; set; }
        //public virtual User Usuario { get; set; }
    }
}
