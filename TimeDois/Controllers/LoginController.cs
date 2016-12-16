using System.Web.Mvc;
using TimeDois.Context;
using TimeDois.Models;
using TimeDois.Repositorio;
using TimeDois.ViewModel;

namespace TimeDois.Controllers
{
    public class LoginController : Controller
    {
        private Time2Entities _contexto;
        private UsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _contexto = new Time2Entities();
            _usuarioRepository = new UsuarioRepository(_contexto);
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logar(LoginViewModel viewModel)
        {
            Session["Login"] = viewModel.Login;
            var usuario = _usuarioRepository.Obter(u => u.Login == viewModel.Login);
            if (usuario == null)
                return RedirectToAction("Index", "Login");
            if (usuario.EhGerencia())
                return RedirectToAction("Listar", "Aprovacao");
            return RedirectToAction("Listar", "Eventos");
        }
    }
}