using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TimeDois.Mapping;
using TimeDois.Models;

namespace TimeDois.Context
{
    public class Time2Entities : DbContext
    {
        public Time2Entities() : base("Time2Entities")
        {
        }

        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Participacao> Participacoes { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            dbModelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            dbModelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            dbModelBuilder.Configurations.Add(new AvaliacaoMap());
            dbModelBuilder.Configurations.Add(new EnderecoMap());
            dbModelBuilder.Configurations.Add(new EventoMap());
            dbModelBuilder.Configurations.Add(new ParticipacaoMap());
            dbModelBuilder.Configurations.Add(new TimeMap());
            dbModelBuilder.Configurations.Add(new UsuarioMap());

            dbModelBuilder.Entity<Usuario>()
                .HasRequired(x => x.Time)
                .WithMany(x => x.Integrantes)
                .Map(x => x.MapKey("IdTime"));

            dbModelBuilder.Entity<Avaliacao>()
                .HasRequired(x => x.UsuarioQueAvaliou)
                .WithMany(x => x.Avaliacoes)
                .Map(x => x.MapKey("IdUsuarioQueAvaliou"));

            dbModelBuilder.Entity<Avaliacao>()
                .HasRequired(x => x.Participacao)
                .WithMany(x => x.Avaliacoes)
                .Map(x => x.MapKey("IdParticipacao"));

            dbModelBuilder.Entity<Endereco>()
                .HasRequired(x => x.Evento)
                .WithOptional(x => x.Endereco);

            dbModelBuilder.Entity<Participacao>()
                .HasRequired(x => x.Evento)
                .WithMany(x => x.Participantes)
                .Map(x => x.MapKey("IdEvento"));

            dbModelBuilder.Entity<Participacao>()
                .HasRequired(x => x.Usuario)
                .WithMany(x => x.Participacoes)
                .Map(x => x.MapKey("IdUsuario"));
        }
    }
}