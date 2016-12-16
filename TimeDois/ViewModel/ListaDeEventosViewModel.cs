using System.Collections.Generic;
using System.Linq;
using TimeDois.Controllers;
using TimeDois.Models;

namespace TimeDois.ViewModel
{
    public class ListaDeEventosViewModel
    {
        public IEnumerable<Evento> Eventos;

        public string CssDoStatusDoInteresse(string login, ICollection<Participacao> participantes)
        {
            if (participantes.Any(participacao => participacao.Usuario.Login == login && participacao.Status == StatusDaParticipacao.Aprovado))
            {
                return "status-aprovado";
            }
            if (participantes.Any(participacao => participacao.Usuario.Login == login && participacao.Status == StatusDaParticipacao.EmAnalise))
            {
                return "status-em-analise";
            }
            if (participantes.Any(participacao => participacao.Usuario.Login == login && participacao.Status == StatusDaParticipacao.Reprovado))
            {
                return "status-reprovado";
            }
            return "";
        }
    }
}