using System.ComponentModel.DataAnnotations;

namespace GestionFastFood.Models
{
    public class User
    {
            [Key]
            public int UsuarioID { get; set; }
            public string Nombre { get; set; }
            public string Correo { get; set; }
            public string Contraseña { get; set; }
            public string Rol { get; set; }
        

    }
}
