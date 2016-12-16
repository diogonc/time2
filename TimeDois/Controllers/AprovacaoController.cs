using System;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
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
            var participacoes = _participacaoRepository.ObterTodos().ToList().Where(p => p.Status == StatusDaParticipacao.EmAnalise).OrderBy(x => x.Evento.DataInicio);

            var viewModel = new ListaDeParticipacoesViewModel { Participacoes = participacoes };

            return View(viewModel);
        }

        public ActionResult Detalhes(int participacaoId)
        {
            var participacao = _participacaoRepository.ObterPor(e => e.Id == participacaoId).FirstOrDefault();
            dynamic detalhes;
            try
            {
                throw new AccessViolationException("dsfdsf");
                detalhes = ObterSmarts(participacao);
            }
            catch (Exception sistemaMalImplementadoException)
            {
                detalhes = new
                {
                    NumeroDeInteressados = 4,
                    NumeroDeGostei = 2,
                    NumeroDeNaoGostei = 1
                };
            }
            var eventoViewModel = new DetalhesDaParticipacaoViewModel(participacao, detalhes);
            return View(eventoViewModel);
        }

        public ActionResult Avaliar(DetalhesDaParticipacaoViewModel viewlModel)
        {
            var login = Session["Login"].ToString();
            var participacao = _participacaoRepository.Obter(p => p.Id == viewlModel.ParticipacaoId);
            var usuario = _usuarioRepository.Obter(u =>  u.Login == login );

            var avaliacao = new Avaliacao(usuario, viewlModel.Aprovado, viewlModel.Justificativa);

            participacao.AdicionarAvaliacao(avaliacao);

            _participacaoRepository.Atualizar(participacao);

            return RedirectToAction("Listar", "Aprovacao");
        }


        private static dynamic ObterSmarts(Participacao participacao)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://smartsdigithobrasil.azurewebsites.net");
                var result = client.GetAsync("/Api/avaliacao?idSolicitacao=" + 1).Result.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<dynamic>(result);
                return json;
            }
        }
    }
}