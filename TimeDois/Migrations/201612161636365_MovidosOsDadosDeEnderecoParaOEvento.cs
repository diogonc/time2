namespace TimeDois.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovidosOsDadosDeEnderecoParaOEvento : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Endereco", "Id", "dbo.Evento");
            DropIndex("dbo.Endereco", new[] { "Id" });
            AddColumn("dbo.Evento", "Logradouro", c => c.String(nullable: false, maxLength: 4000));
            AddColumn("dbo.Evento", "Cidade", c => c.String(nullable: false, maxLength: 4000));
            AddColumn("dbo.Evento", "Estado", c => c.String(nullable: false, maxLength: 4000));
            DropTable("dbo.Endereco");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(nullable: false, maxLength: 4000),
                        Cidade = c.String(nullable: false, maxLength: 4000),
                        Estado = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Evento", "Estado");
            DropColumn("dbo.Evento", "Cidade");
            DropColumn("dbo.Evento", "Logradouro");
            CreateIndex("dbo.Endereco", "Id");
            AddForeignKey("dbo.Endereco", "Id", "dbo.Evento", "Id");
        }
    }
}
