using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
//using AspNetCore;
using GestionFastFood.Models;

namespace GestionFastFood.Models
{
    public class Posicion
    {
        [Key]
        public int PosicionId { get; set; }
        public string Nombre { get; set; }
    }
}

