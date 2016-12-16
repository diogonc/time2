using System;
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
            var eventos = _eventoRepository.ObterTodos();
            var viewModel = new ListaDeEventosViewModel() {Eventos =  eventos};

            return View(viewModel);
        }

        public ActionResult Detalhes(int eventoId)
        {
            var evento = new Evento
            {
                Nome = "Agile Trends",
                Descricao = "A Agile Trends é a principal conferência sobre tendências em agilidade do Brasil, reunindo os maiores especialistas e formadores de opinião da área.",
                DataInicio = new DateTime(2017, 04, 12),
                DataFim = new DateTime(2017, 04, 13),
                Endereco = new Endereco { Cidade = "São Paulo", Estado = "SP", Logradouro = "Av. Dr. Enéas de Carvalho Aguiar, 23" },
                ValorDeInscricao = 450.00m,
                Link = "http://agiletrendsbr.com/",
                UrlDaLogo = "http://agiletrendsbr.com/2014/wp-content/uploads/2014/02/logo-agiletrends-350x218.png"
            };
            return View(evento);
        }

        public ActionResult Participar(int eventoId)
        {
            var login = (string) Session["Login"];
            var usuario = _usuarioRepository.Obter(u => u.Login == login);
            var evento = _eventoRepository.Obter(e => e.Id == eventoId);
            evento.TenhoInteresse(usuario);
            _eventoRepository.Atualizar(evento);
            return RedirectToAction("Detalhes", "Eventos", new {eventoId = evento.Id});
        }
    }
}