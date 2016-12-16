using System;
using System.Collections.Generic;
using System.Linq;
using TimeDois.Models.Base;

namespace TimeDois.Models
{
    public class Evento : Entidade
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorDeInscricao { get; set; }
        public decimal ValorDaPassagem { get; set; }
        public string UrlDaLogo { get; set; }
        public string Link { get; set; }
        public string Descricao { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Endereco { get { return Logradouro + ", " + Cidade + " - " + Estado; } }

        public virtual ICollection<Participacao> Participantes { get; set; }
        public decimal ValorTotal { get { return ValorDaPassagem + ValorDeInscricao; } }

        public Evento()
        {
            Participantes = new List<Participacao>();
        }

        public Participacao ManifestarInteresse(Usuario usuario)
        {
            var participacao = new Participacao(usuario, this);
            Participantes.Add(participacao);
            return participacao;
        }
    }
}