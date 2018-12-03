namespace VendasBack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Eventos",
                c => new
                    {
                        IdEvento = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                        data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdEvento);
            
            CreateTable(
                "dbo.EventoOrcamentos",
                c => new
                    {
                        IdEventoOrcamento = c.Int(nullable: false, identity: true),
                        quantidade = c.Int(nullable: false),
                        dataPedido = c.DateTime(nullable: false),
                        cliente = c.String(nullable: false),
                        IdEventoFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdEventoOrcamento)
                .ForeignKey("dbo.Eventos", t => t.IdEventoFK, cascadeDelete: true)
                .Index(t => t.IdEventoFK);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        IdPedido = c.Int(nullable: false, identity: true),
                        quantidade = c.Int(nullable: false),
                        dataPedido = c.DateTime(nullable: false),
                        cliente = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdPedido);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        idVenda = c.Int(nullable: false, identity: true),
                        idFuncionario = c.Int(nullable: false),
                        quantidade = c.Int(nullable: false),
                        qualidade = c.Int(nullable: false),
                        avaliacao = c.Int(nullable: false),
                        data = c.DateTime(nullable: false),
                        Cliente = c.String(),
                    })
                .PrimaryKey(t => t.idVenda);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventoOrcamentos", "IdEventoFK", "dbo.Eventos");
            DropIndex("dbo.EventoOrcamentos", new[] { "IdEventoFK" });
            DropTable("dbo.Vendas");
            DropTable("dbo.Pedidos");
            DropTable("dbo.EventoOrcamentos");
            DropTable("dbo.Eventos");
        }
    }
}
