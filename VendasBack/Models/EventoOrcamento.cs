using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace VendasBack.Models
{
    [Table("EventoOrcamentos")]
    public class EventoOrcamento
    {
        [Key]
        public int IdEventoOrcamento { get; set; }
        [Required]
        public string Fornecedor { get; set; }
        public double Gasto { get; set; }
        public double Orcamento { get; set; }

        //Foreign key for Evento
        public int IdEventoFK { get; set; }
        public Evento evento { get; set; }
    }
}