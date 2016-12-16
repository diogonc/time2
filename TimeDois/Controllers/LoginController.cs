using System.Web.Mvc;
using TimeDois.Models;
using TimeDois.Repositorio;
using TimeDois.ViewModel;

namespace TimeDois.Controllers
{
    public class LoginController : Controller
    {
        private UsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
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
            {
                _usuarioRepository.Criar(new Usuario(viewModel.Login, viewModel.Senha));
            }
            return RedirectToAction("Listar", "Eventos");
        }
    }
}