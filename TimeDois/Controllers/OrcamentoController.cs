using System.Linq;
using System.Web.Mvc;
using TimeDois.Context;
using TimeDois.Models;
using TimeDois.Repositorio;
using TimeDois.ViewModel;

namespace TimeDois.Controllers
{
    public class OrcamentoController : Controller
    {
        private Time2Entities _contexto;
        private UsuarioRepository _usuarioRepository;
        private ParticipacaoRepository _participacoesRepository;

        public OrcamentoController()
        {
            _contexto = new Time2Entities();
            _usuarioRepository = new UsuarioRepository(_contexto);
            _participacoesRepository = new ParticipacaoRepository(_contexto);
        }

        public ActionResult Index()
        {
            var login = (string) Session["Login"];
            var timeLogado = _usuarioRepository.Obter(u => u.Login == login).Time;
            var usuariosDoTime = _usuarioRepository.ObterTodos().ToList().Where(u => u.Time == timeLogado);
            var participacoes = _participacoesRepository.ObterTodos().ToList().Where(p => usuariosDoTime.Contains(p.Usuario) && p.Status == StatusDaParticipacao.Aprovado);
            var viewModel = new OrcamentoViewModel
            {
                ValorDisponivel = timeLogado.OrcamentoTotal,
                ValorUtilizado = participacoes.Sum(p => p.Evento.ValorDeInscricao + p.Evento.ValorDaPassagem)
            };
            
            return View(viewModel);
        }
    }
}