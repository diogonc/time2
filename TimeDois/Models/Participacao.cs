using System.Collections.Generic;

namespace TimeDois.Models
{
    public class Participacao
    {
        public Evento Evento { get; set; }
        public Usuario Usuario { get; set; }
        public IEnumerable<Avaliacao> Avaliacoes { get; set; } 
    }

}