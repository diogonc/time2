using System.Web.Http.Results;
using System.Web.Mvc;
using TimeDois.Models;

namespace TimeDois.Controllers
{
    public class EventosController : Controller
    {
        public ActionResult Listar()
        {
            return View();
        }

        public ActionResult Detalhes(int eventoId)
        {
            var evento = new Evento();
            return View(evento);
        }

        public ActionResult Participar(string eventoid)
        {
            var usuario = new Usuario((string) Session["Login"]);
            var evento = new Evento();
            evento.TenhoInteresse(usuario);
            return RedirectToAction("Detalhes", "Eventos", new {eventoId = evento.Id});
        }
    }
}