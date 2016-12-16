namespace TimeDois.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarGrupoDeUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "GrupoDeUsuario", c => c.Int(nullable: false, defaultValue: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "GrupoDeUsuario");
        }
    }
}
