using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TimeDois.Models;

namespace TimeDois.Mapping
{
    public class AvaliacaoMap : EntityTypeConfiguration<Avaliacao>
    {
        public AvaliacaoMap()
        {
            ToTable("Avaliacao");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(x => x.Aprovado).HasColumnType("bit").IsRequired();
            Property(x => x.Justificativa).HasColumnType("nvarchar").HasMaxLength(null);
            Property(x => x.TipoDeAvaliacao).HasColumnType("int").IsRequired();
        }
    }
}