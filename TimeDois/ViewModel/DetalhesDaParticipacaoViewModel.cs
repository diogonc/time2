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
        public virtual string Justificativa { get; set; }
        public virtual bool Aprovado { get; set; }
        public virtual int ParticipacaoId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Evento Evento { get; set; }
        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }
        public int NumeroDeInteressados { get; set; }
        public int NumeroDeGostei { get; set; }
        public int NumeroDeNaoGostei { get; set; }

        public DetalhesDaParticipacaoViewModel(Participacao participacao, dynamic detalhes)
        {
            Usuario = participacao.Usuario;
            Evento = participacao.Evento;
            Avaliacoes = participacao.Avaliacoes;
            ParticipacaoId = participacao.Id;
            NumeroDeInteressados = detalhes.NumeroDeInteressados;
            NumeroDeGostei = detalhes.NumeroDeGostei;
            NumeroDeNaoGostei = detalhes.NumeroDeNaoGostei;
        }
    }
}