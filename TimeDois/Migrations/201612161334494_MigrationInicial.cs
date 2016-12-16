namespace TimeDois.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Avaliacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aprovado = c.Boolean(nullable: false),
                        Justificativa = c.String(nullable: false, maxLength: 4000),
                        TipoDeAvaliacao = c.Int(nullable: false),
                        IdParticipacao = c.Int(nullable: false),
                        IdUsuarioQueAvaliou = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Participacao", t => t.IdParticipacao)
                .ForeignKey("dbo.Usuario", t => t.IdUsuarioQueAvaliou)
                .Index(t => t.IdParticipacao)
                .Index(t => t.IdUsuarioQueAvaliou);
            
            CreateTable(
                "dbo.Participacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdEvento = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Evento", t => t.IdEvento)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario)
                .Index(t => t.IdEvento)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 4000),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                        ValorDeInscricao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UrlDaLogo = c.String(nullable: false, maxLength: 4000),
                        Descricao = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(nullable: false, maxLength: 4000),
                        Cidade = c.String(nullable: false, maxLength: 4000),
                        Estado = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Evento", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 4000),
                        Nome = c.String(nullable: false, maxLength: 4000),
                        Senha = c.String(nullable: false, maxLength: 4000),
                        IdTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Time", t => t.IdTime)
                .Index(t => t.IdTime);
            
            CreateTable(
                "dbo.Time",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Avaliacao", "IdUsuarioQueAvaliou", "dbo.Usuario");
            DropForeignKey("dbo.Avaliacao", "IdParticipacao", "dbo.Participacao");
            DropForeignKey("dbo.Participacao", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "IdTime", "dbo.Time");
            DropForeignKey("dbo.Participacao", "IdEvento", "dbo.Evento");
            DropForeignKey("dbo.Endereco", "Id", "dbo.Evento");
            DropIndex("dbo.Usuario", new[] { "IdTime" });
            DropIndex("dbo.Endereco", new[] { "Id" });
            DropIndex("dbo.Participacao", new[] { "IdUsuario" });
            DropIndex("dbo.Participacao", new[] { "IdEvento" });
            DropIndex("dbo.Avaliacao", new[] { "IdUsuarioQueAvaliou" });
            DropIndex("dbo.Avaliacao", new[] { "IdParticipacao" });
            DropTable("dbo.Time");
            DropTable("dbo.Usuario");
            DropTable("dbo.Endereco");
            DropTable("dbo.Evento");
            DropTable("dbo.Participacao");
            DropTable("dbo.Avaliacao");
        }
    }
}
