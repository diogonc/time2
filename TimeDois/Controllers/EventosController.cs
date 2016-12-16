using System.Web.Mvc;

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
            return View();
        }
    }
}