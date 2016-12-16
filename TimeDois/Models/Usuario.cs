using System.Collections.Generic;
using TimeDois.Models.Base;

namespace TimeDois.Models
{
    public class Usuario : Entidade
    {
        public Usuario()
        {
            Avaliacoes = new List<Avaliacao>();
        }

        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public virtual Time Time { get; set; }
        
        public virtual ICollection<Participacao> Participacoes { get; set; }
        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}