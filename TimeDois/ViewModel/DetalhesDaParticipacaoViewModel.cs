using System.Collections.Generic;
using TimeDois.Models;

namespace TimeDois.ViewModel
{
    public class DetalhesDaParticipacaoViewModel
    {
        public DetalhesDaParticipacaoViewModel()
        {
            Avaliacoes = new List<Avaliacao>();
        }
        public virtual int Id { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Evento Evento { get; set; }
        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }

        public DetalhesDaParticipacaoViewModel(Participacao participacao)
        {
            this.Usuario = participacao.Usuario;
            this.Evento = participacao.Evento;
            this.Avaliacoes = participacao.Avaliacoes;
        }
    }
}