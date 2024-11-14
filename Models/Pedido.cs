using System.ComponentModel.DataAnnotations;

namespace GestionFastFood.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoID { get; set; }
        public int MesaID { get; set; }
        public int Posicion { get; set; }
        public string Estado { get; set; }

        public virtual Mesa Mesa { get; set; }
        public virtual ICollection<PedidoProducto> PedidoProductos { get; set; }
    }
}
