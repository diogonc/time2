namespace TimeDois.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoLinkAoEvento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evento", "Link", c => c.String(nullable: false, maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Evento", "Link");
        }
    }
}
