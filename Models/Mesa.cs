using System.ComponentModel.DataAnnotations;

namespace GestionFastFood.Models
{
    public class Mesa
    {
        [Key]
        public int MesaId { get; set; }
        public int NumeroPosiciones { get; set; }
        public string Estado { get; set; }
        public int NumeroMesa { get; set; }
    }
}
