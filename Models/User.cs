//using Microsoft.AspNetCore.Identity.Entityframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionFastFood.Models
{
    public class User//Representa la estructura de la tabla en la base de datos
    {
          [Key]
          public int UsuarioID { get; set; }

        
         public string Nombre { get; set; }

        [Column("Email")]
        public string Correo { get; set; }

        [Column("Password")]
        public string Contraseña { get; set; }

        public string Rol { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
        //public string Email { get; internal set; }
        //public string Password { get; internal set; }
    }
}
