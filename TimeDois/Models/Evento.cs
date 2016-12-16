using System;
using System.Collections.Generic;

namespace TimeDois.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorDeInscricao { get; set; }
        public string UrlDaLogo { get; set; }
        public string Descricao { get; set; }
        public IList<Participacao> Participantes { get; set; }

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