namespace VendasBack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventoOrcamentoCorrecoes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventoOrcamentos", "Fornecedor", c => c.String(nullable: false));
            AddColumn("dbo.EventoOrcamentos", "Gasto", c => c.Double(nullable: false));
            AddColumn("dbo.EventoOrcamentos", "Orcamento", c => c.Double(nullable: false));
            DropColumn("dbo.EventoOrcamentos", "quantidade");
            DropColumn("dbo.EventoOrcamentos", "dataPedido");
            DropColumn("dbo.EventoOrcamentos", "cliente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventoOrcamentos", "cliente", c => c.String(nullable: false));
            AddColumn("dbo.EventoOrcamentos", "dataPedido", c => c.DateTime(nullable: false));
            AddColumn("dbo.EventoOrcamentos", "quantidade", c => c.Int(nullable: false));
            DropColumn("dbo.EventoOrcamentos", "Orcamento");
            DropColumn("dbo.EventoOrcamentos", "Gasto");
            DropColumn("dbo.EventoOrcamentos", "Fornecedor");
        }
    }
}
