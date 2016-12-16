using System;

namespace TimeDois.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorDeInscricao { get; set; }
        public string UrlDaLogo { get; set; }
        public string Descricao { get; set; }
    }
}