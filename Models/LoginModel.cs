using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GestionFastFood;
using System.ComponentModel.DataAnnotations;

namespace GestionFastFood.Models
{
	public class LoginModel
	{
		public int Id { get; set; }
		public class LoginViewModel
		{
			[Required(ErrorMessage = "El correo es obligatorio")]
			[EmailAddress(ErrorMessage = "Formato de correo inválido")]
			public string Correo { get; set; }

			[Required(ErrorMessage = "La contraseña es obligatoria")]
			[DataType(DataType.Password)]
			public string Contraseña { get; set; }

			[Display(Name = "Recordarme")]
			public bool RememberMe { get; set; }
		}

	}
}
