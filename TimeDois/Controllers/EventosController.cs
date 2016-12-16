using System.Web.Http.Results;
using System.Web.Mvc;
using TimeDois.Models;
using TimeDois.Repositorio;

namespace TimeDois.Controllers
{
    public class EventosController : Controller
    {
        private UsuarioRepository _usuarioRepository;
        private EventoRepository _eventoRepository;

        public EventosController()
        {
            _usuarioRepository = new UsuarioRepository();
            _eventoRepository = new EventoRepository();
        }
        public ActionResult Listar()
        {
            return View();
        }

        public ActionResult Detalhes(int eventoId)
        {
            var evento = new Evento();
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