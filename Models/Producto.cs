using GestionFastFood.Models;
using System.ComponentModel.DataAnnotations;

namespace GestionFastFood.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public int PedidoId { get; set; }
        public int PosicionId { get; set; }


        public virtual Pedido Pedido { get; set; } = new Pedido();
        public virtual Posicion Posicion { get; set; } = new Posicion();
    }
}
