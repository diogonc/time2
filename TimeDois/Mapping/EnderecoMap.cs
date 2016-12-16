using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TimeDois.Models;

namespace TimeDois.Mapping
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            ToTable("Endereco");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(x => x.Cidade).HasColumnType("nvarchar").HasMaxLength(null).IsRequired();
            Property(x => x.Estado).HasColumnType("nvarchar").HasMaxLength(null).IsRequired();
            Property(x => x.Logradouro).HasColumnType("nvarchar").HasMaxLength(null).IsRequired();
        }
    }
}