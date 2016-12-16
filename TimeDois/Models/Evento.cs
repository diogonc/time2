using System;
using System.Collections.Generic;
using TimeDois.Models.Base;

namespace TimeDois.Models
{
    public class Evento : Entidade
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorDeInscricao { get; set; }
        public string UrlDaLogo { get; set; }
        public string Link { get; set; }
        public string Descricao { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Participacao> Participantes { get; set; }

        public Evento()
        {
            Participantes = new List<Participacao>();
        }

        public void TenhoInteresse(Usuario usuario)
        {
            Participantes.Add(new Participacao(usuario, this));
        }
    }
}