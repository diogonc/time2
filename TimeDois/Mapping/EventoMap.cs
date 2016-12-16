using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TimeDois.Models;

namespace TimeDois.Mapping
{
    public class EventoMap : EntityTypeConfiguration<Evento>
    {
        public EventoMap()
        {
            ToTable("Evento");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(x => x.Nome).HasColumnType("nvarchar").HasMaxLength(null).IsRequired();
            Property(x => x.UrlDaLogo).HasColumnType("nvarchar").HasMaxLength(null).IsRequired();
            Property(x => x.Descricao).HasColumnType("nvarchar").HasMaxLength(null).IsRequired();
            Property(x => x.ValorDeInscricao).HasColumnType("decimal").IsRequired();
            Property(x => x.DataInicio).HasColumnType("datetime").IsRequired();
            Property(x => x.DataFim).HasColumnType("datetime").IsRequired();
        }
    }
}