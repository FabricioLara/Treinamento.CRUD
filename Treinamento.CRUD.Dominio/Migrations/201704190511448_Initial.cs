namespace Treinamento.CRUD.Dominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CPF = c.String(),
                        Nome = c.String(),
                        Telefone = c.String(),
                        Endereco = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Dependentes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CPF = c.String(),
                        Nome = c.String(),
                        Info = c.String(),
                        Cliente_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ID)
                .Index(t => t.Cliente_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dependentes", "Cliente_ID", "dbo.Clientes");
            DropIndex("dbo.Dependentes", new[] { "Cliente_ID" });
            DropTable("dbo.Dependentes");
            DropTable("dbo.Clientes");
        }
    }
}
