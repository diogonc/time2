using System.Web.Mvc;
using TimeDois.Models;
using TimeDois.ViewModel;

namespace TimeDois.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logar(LoginViewModel viewModel)
        {
            Session["Login"] = viewModel.Login;

            return RedirectToAction("Listar", "Eventos");
        }
    }
}