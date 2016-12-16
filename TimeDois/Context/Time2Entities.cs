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
        public DbSet<Participacao> Participacoes { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            dbModelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            dbModelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Account
            dbModelBuilder.Configurations.Add(new AvaliacaoMap());
            dbModelBuilder.Configurations.Add(new EventoMap());
            dbModelBuilder.Configurations.Add(new ParticipacaoMap());
            dbModelBuilder.Configurations.Add(new TimeMap());
            dbModelBuilder.Configurations.Add(new UsuarioMap());


        }
    }
}