using System;

namespace TimeDois.Models
{
    public class Evento
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorDeInscricao { get; set; }
        public string UrlDaLogo { get; set; }
        public string Descricao { get; set; }
        private IEnumerable<Participacao> participantes { get; }

        public Evento()
        {
            participantes = new List<Participacao>();
        }

        public void tenhoInteresse(Usuario usuario)
        {
            participantes.add(new Participacao(usuario, evento));
        }
    }
}