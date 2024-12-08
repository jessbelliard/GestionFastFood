using GestionFastFood.Models;
using System.ComponentModel.DataAnnotations;

namespace GestionFastFood.Models
{
    public class PedidoProducto
	{
		[Key]
		public int PedidoID { get; set; }
		public int ProductoID { get; set; }
		public int Cantidad { get; set; }


		public Pedido Pedido { get; set; }
		public Producto Producto { get; set; }
	}
}
//public int Id { get; set; } = 1;
