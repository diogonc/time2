using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TimeDois.Models;

namespace TimeDois.Mapping
{
    public class ParticipacaoMap : EntityTypeConfiguration<Participacao>
    {
        public ParticipacaoMap()
        {
            ToTable("Participacao");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(x => x.Justificativa).HasColumnType("nvarchar").IsRequired();
            Property(x => x.PercentualDeSubsidio).HasColumnType("int").IsRequired();
        }
    }
}