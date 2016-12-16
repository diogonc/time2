using System.Collections.Generic;

namespace TimeDois.Models
{
    public class Participacao
    {
        public Usuario Usuario { get; set; }
        public Evento Evento { get; set; }
        public IEnumerable<Avaliacao> Avaliacoes { get; set; } 

        public Participacao(Usuario usuario, Evento evento)
        {
            Usuario = usuario;
            Evento = evento;
        }
    }

}