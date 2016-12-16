using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TimeDois.Models;

namespace TimeDois.Mapping
{
    public class TimeMap : EntityTypeConfiguration<Time>
    {
        public TimeMap()
        {
            ToTable("Time");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(x => x.Nome).HasColumnType("nvarchar").HasMaxLength(null).IsRequired();
            Property(x => x.OrcamentoTotal).HasColumnType("decimal").IsRequired();
        }
    }
}