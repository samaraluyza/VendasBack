using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VendasBack.Utils;


namespace VendasBack.Models
{
    [Table("Vendas")]
    public class Venda
    {
        [Key]
        public int idVenda { get; set; }
        [Required]
        public int idFuncionario { get; set; }
        [Required]
        public int quantidade { get; set; }
        [Required]
        public QualidadeProduto qualidade { get; set; }
        public Avaliacao avaliacao { get; set; }
        public DateTime data { get; set; }
        public string Cliente { get; set; }

    }
}