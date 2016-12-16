namespace TimeDois.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovendoRequiredDaJustificativa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Avaliacao", "Justificativa", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Avaliacao", "Justificativa", c => c.String(nullable: false, maxLength: 4000));
        }
    }
}
