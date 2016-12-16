using System.Collections.Generic;
using System.Linq;
using TimeDois.Models.Base;

namespace TimeDois.Models
{
    public class Participacao : Entidade
    {
        public virtual Usuario Usuario { get; set; }
        public virtual Evento Evento { get; set; }
        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }

        public virtual StatusDaParticipacao Status 
        {
            get
            {
                if (Avaliacoes.Any(a => a.UsuarioQueAvaliou.EhGerencia() && a.Aprovado))
                {
                    return StatusDaParticipacao.Aprovado;
                }
                return Avaliacoes.Any(a => a.UsuarioQueAvaliou.EhGerencia() && !a.Aprovado) ? StatusDaParticipacao.Reprovado : StatusDaParticipacao.EmAnalise;
            }
            
        }

        protected Participacao() { }

        public Participacao(Usuario usuario, Evento evento)
        {
            Usuario = usuario;
            Evento = evento;

            Avaliacoes = new List<Avaliacao>();
        }

        public void AdicionarAvaliacao(Avaliacao avaliacao)
        {
            Avaliacoes.Add(avaliacao);
        }
    }
}