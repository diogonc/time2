using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using TimeDois.Context;
using TimeDois.Models;
using TimeDois.Repositorio;
using TimeDois.ViewModel;

namespace TimeDois.Controllers
{
    public class EventosController : Controller
    {
        private Time2Entities _contexto;
        private UsuarioRepository _usuarioRepository;
        private EventoRepository _eventoRepository;

        public EventosController()
        {
            _contexto = new Time2Entities();
            _usuarioRepository = new UsuarioRepository(_contexto);
            _eventoRepository = new EventoRepository(_contexto);
        }

        public ActionResult Listar()
        {
            var eventos = _eventoRepository.ObterTodos().ToList().OrderBy(x => x.DataInicio);
            var viewModel = new ListaDeEventosViewModel { Eventos = eventos };

            return View(viewModel);
        }

        public ActionResult Detalhes(int eventoId)
        {
            var evento = _eventoRepository.ObterPor(e => e.Id == eventoId).FirstOrDefault();
            var eventoViewModel = new DetalhesDoEventoViewModel(evento);
            return View(eventoViewModel);
        }

        public ActionResult Participar(int eventoId)
        {
            var login = (string)Session["Login"];
            var usuario = _usuarioRepository.Obter(u => u.Login == login);
            var evento = _eventoRepository.Obter(e => e.Id == eventoId);
            var participacao = evento.ManifestarInteresse(usuario);
            _eventoRepository.Atualizar(evento);

            //ChamarSmarts(participacao);

            return RedirectToAction("Detalhes", "Eventos", new { eventoId = evento.Id });
        }

        private static void ChamarSmarts(Participacao participacao)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://smartsdigithobrasil.azurewebsites.net");
                var content = new FormUrlEncodedContent(new[] {
                    new KeyValuePair<string, string>("IdSolicitacao", participacao.Id.ToString()),
                    new KeyValuePair<string, string>("IdSolicitante", participacao.Usuario.Id.ToString()),
                    new KeyValuePair<string, string>("IdEvento", participacao.Evento.Id.ToString()),
                    new KeyValuePair<string, string>("IdTime", participacao.Usuario.Time.Id.ToString()),
                    new KeyValuePair<string, string>("Solicitante", participacao.Usuario.Nome),
                    new KeyValuePair<string, string>("Evento", participacao.Evento.Nome)
                });
                client.PostAsync("/Api/adicionar", content);
            }
        }
    }
}