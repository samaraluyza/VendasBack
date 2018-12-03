using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VendasBack.Models
{
    public class VendasBackContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public VendasBackContext() : base("name=VendasBackContext")
        {
        }

        public System.Data.Entity.DbSet<VendasBack.Models.Venda> Vendas { get; set; }

        public System.Data.Entity.DbSet<VendasBack.Models.Evento> Eventoes { get; set; }

        public System.Data.Entity.DbSet<VendasBack.Models.EventoOrcamento> EventoOrcamentoes { get; set; }

        public System.Data.Entity.DbSet<VendasBack.Models.Pedido> Pedidoes { get; set; }
    }
}
