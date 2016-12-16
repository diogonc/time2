namespace TimeDois.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoJustificativaEPercentualDeSubsidio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participacao", "Justificativa", c => c.String(nullable: false, maxLength: 4000));
            AddColumn("dbo.Participacao", "PercentualDeSubsidio", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Participacao", "PercentualDeSubsidio");
            DropColumn("dbo.Participacao", "Justificativa");
        }
    }
}
