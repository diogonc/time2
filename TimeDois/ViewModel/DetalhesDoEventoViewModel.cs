using System;
using System.Collections.Generic;
using System.Linq;
using TimeDois.Models;

namespace TimeDois.ViewModel
{
    public class DetalhesDoEventoViewModel
    {
        public DetalhesDoEventoViewModel(Evento evento)
        {
            UrlDaLogo = evento.UrlDaLogo;
            Nome = evento.Nome;
            Descricao = evento.Descricao;
            Id = evento.Id;
            Participantes = evento.Participantes;
            DataInicio = evento.DataInicio;
            DataFim = evento.DataFim;
            Cidade = evento.Cidade;
            Estado = evento.Estado;
            ValorDeInscricao = evento.ValorDeInscricao;
            Endereco = evento.Endereco;
        }

        public string Endereco { get; set; }

        public string UrlDaLogo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Id { get; set; }
        public virtual ICollection<Participacao> Participantes { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public decimal ValorDeInscricao { get; set; }

        public string CssDoBotaoDeInteresse(string login)
        {
            if (Participantes.Any(participacao => participacao.Usuario.Login == login && participacao.Status == StatusDaParticipacao.Aprovado))
            {
                return "is-success is-disabled";
            }
            if (Participantes.Any(participacao => participacao.Usuario.Login == login && participacao.Status == StatusDaParticipacao.EmAnalise))
            {
                return "is-warning is-disabled";
            }
            if (Participantes.Any(participacao => participacao.Usuario.Login == login && participacao.Status == StatusDaParticipacao.Reprovado))
            {
                return "is-danger is-disabled";
            }
            return "";
        }

        public string TextoDoBotaoDeInteresse(string login)
        {
            if (Participantes.Any(participacao => participacao.Usuario.Login == login && participacao.Status == StatusDaParticipacao.Aprovado))
            {
                return "Eu vou!";
            }
            if (Participantes.Any(participacao => participacao.Usuario.Login == login && participacao.Status == StatusDaParticipacao.EmAnalise))
            {
                return "Em análise";
            }
            if (Participantes.Any(participacao => participacao.Usuario.Login == login && participacao.Status == StatusDaParticipacao.Reprovado))
            {
                return "Eu não vou!";
            }
            return "Quero ir!";
        }

    }
}