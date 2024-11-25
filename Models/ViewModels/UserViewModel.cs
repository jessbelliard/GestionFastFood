namespace GestionFastFood.Models.ViewModels
{
    //Para manejar datos de usuario en vistas generales (crear, editar, eliminar);CRUD en vistas administrativas..
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
    }
}
