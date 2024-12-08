using GestionFastFood.Models;
using System.ComponentModel.DataAnnotations;

namespace GestionFastFood.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoID { get; set; }
        public string Detalle { get; set; }
        public string Estado { get; set; }
        public int MesaID { get; set; }
        public int PosicionId { get; set; }

        public virtual Mesa Mesa { get; set; }
        public Posicion Posicion { get; set; }

        public virtual ICollection<PedidoProducto> PedidoProductos { get; set; }
    }
}
