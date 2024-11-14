using GestionFastFood.Models;
using System.ComponentModel.DataAnnotations;

namespace GestionFastFood.Models
{
    public class Factura
    {
        [Key] public int Id { get; set; }
        public int FacturaID { get; set; }
        public int PedidoID { get; set; }
        public decimal Total { get; set; }
        public decimal Itbis { get; set; }
        public decimal TotalConImpuestos { get; set; }
        public string TipoFactura { get; set; }
        public string Estado { get; set; }

        public virtual Pedido Pedido { get; set; }
    }
}
