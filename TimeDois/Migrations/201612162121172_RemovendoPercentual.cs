namespace TimeDois.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovendoPercentual : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Participacao", "Justificativa");
            DropColumn("dbo.Participacao", "PercentualDeSubsidio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Participacao", "PercentualDeSubsidio", c => c.Int(nullable: false));
            AddColumn("dbo.Participacao", "Justificativa", c => c.String(nullable: false, maxLength: 4000));
        }
    }
}
