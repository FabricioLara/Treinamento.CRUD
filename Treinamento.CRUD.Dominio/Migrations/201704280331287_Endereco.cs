namespace Treinamento.CRUD.Dominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Endereco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        UF_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UFs", t => t.UF_ID)
                .Index(t => t.UF_ID);
            
            CreateTable(
                "dbo.UFs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sigla = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Clientes", "Logradouro", c => c.String());
            AddColumn("dbo.Clientes", "Numero", c => c.String());
            AddColumn("dbo.Clientes", "CEP", c => c.String());
            AddColumn("dbo.Clientes", "Cidade_ID", c => c.Int());
            AddColumn("dbo.Clientes", "UF_ID", c => c.Int());
            CreateIndex("dbo.Clientes", "Cidade_ID");
            CreateIndex("dbo.Clientes", "UF_ID");
            AddForeignKey("dbo.Clientes", "Cidade_ID", "dbo.Cidades", "ID");
            AddForeignKey("dbo.Clientes", "UF_ID", "dbo.UFs", "ID");
            DropColumn("dbo.Clientes", "Endereco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Endereco", c => c.String());
            DropForeignKey("dbo.Clientes", "UF_ID", "dbo.UFs");
            DropForeignKey("dbo.Clientes", "Cidade_ID", "dbo.Cidades");
            DropForeignKey("dbo.Cidades", "UF_ID", "dbo.UFs");
            DropIndex("dbo.Clientes", new[] { "UF_ID" });
            DropIndex("dbo.Clientes", new[] { "Cidade_ID" });
            DropIndex("dbo.Cidades", new[] { "UF_ID" });
            DropColumn("dbo.Clientes", "UF_ID");
            DropColumn("dbo.Clientes", "Cidade_ID");
            DropColumn("dbo.Clientes", "CEP");
            DropColumn("dbo.Clientes", "Numero");
            DropColumn("dbo.Clientes", "Logradouro");
            DropTable("dbo.UFs");
            DropTable("dbo.Cidades");
        }
    }
}
