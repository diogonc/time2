using System.Collections.Generic;
using TimeDois.Models.Base;

namespace TimeDois.Models
{
    public class Participacao : Entidade
    {
        public virtual Usuario Usuario { get; set; }
        public virtual Evento Evento { get; set; }
        public virtual ICollection<Avaliacao> Avaliacoes { get; set; } 

        public Participacao(Usuario usuario, Evento evento)
        {
            Usuario = usuario;
            Evento = evento;
        }
    }

}