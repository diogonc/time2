using System.Linq;
using System.Web.Mvc;
using TimeDois.Context;
using TimeDois.Models;
using TimeDois.Repositorio;
using TimeDois.ViewModel;

namespace TimeDois.Controllers
{
    public class AprovacaoController : Controller
    {
        private Time2Entities _contexto;
        private ParticipacaoRepository _participacaoRepository;
        private UsuarioRepository _usuarioRepository;

        public AprovacaoController()
        {
            _contexto = new Time2Entities();
            _participacaoRepository = new ParticipacaoRepository(_contexto);
            _usuarioRepository = new UsuarioRepository(_contexto);
        }

        public ActionResult Listar()
        {
            var participacoes = _participacaoRepository.ObterTodos().ToList().Where(p => !p.Avaliacoes.Any(a => a.UsuarioQueAvaliou.EhGerencia()));

            var viewModel = new ListaDeParticipacoesViewModel { Participacoes = participacoes };

            return View(viewModel);
        }

        public ActionResult Detalhes(int participacaoId)
        {
            var participacao = _participacaoRepository.ObterPor(e => e.Id == participacaoId).FirstOrDefault();
            var eventoViewModel = new DetalhesDaParticipacaoViewModel(participacao);
            return View(eventoViewModel);
        }

        public ActionResult Avaliar(int participacaoId, bool aprovado)
        {
            var login = Session["Login"].ToString();
            var participacao = _participacaoRepository.Obter(p => p.Id == participacaoId);
            var usuario = _usuarioRepository.Obter(u =>  u.Login == login );
            var justificativa = aprovado ? "Porque sim" : "Porque não";
            
            var avaliacao = new Avaliacao(usuario, aprovado, justificativa);

            participacao.AdicionarAvaliacao(avaliacao);

            _participacaoRepository.Atualizar(participacao);

            return RedirectToAction("Listar", "Aprovacao");
        }
    }
}