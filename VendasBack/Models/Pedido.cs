using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendasBack.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }
        [Required]
        public int quantidade { get; set; }
        [Required]
        public System.DateTime? dataPedido { get; set; }
        [Required]
        public string cliente { get; set; }
    }
}