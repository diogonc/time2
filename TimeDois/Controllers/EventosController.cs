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
    }
}