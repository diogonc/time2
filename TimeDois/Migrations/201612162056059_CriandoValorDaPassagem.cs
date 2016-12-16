namespace TimeDois.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriandoValorDaPassagem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evento", "ValorDaPassagem", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Evento", "ValorDaPassagem");
        }
    }
}
