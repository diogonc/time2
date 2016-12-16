using System.Collections.Generic;
using TimeDois.Models.Base;

namespace TimeDois.Models
{
    public class Time : Entidade
    {
        public Time()
        {
            Integrantes = new List<Usuario>();
        }

        public string Nome { get; set; } 
        public decimal OrcamentoTotal { get; set; }
        public virtual ICollection<Usuario> Integrantes { get; set; }
    }
}