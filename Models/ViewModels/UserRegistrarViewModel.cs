using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using GestionFastFood;

namespace GestionFastFood.Models.ViewModels
{
    public class UserRegistrarViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public string Rol { get; set; } // Puedes usar un dropdown para roles: Mesero, Caja, Administrador.
        //Revisar
    }
}
