using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace VendasBack.Models
{
    [Table("Eventos")]
    public class Evento
    {
        [Key]
        public int IdEvento { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public System.DateTime? data { get; set; }

        [ForeignKey("IdEventoFK")]
        public ICollection<EventoOrcamento> eventoOrcamentos { get; set; }
    }
}