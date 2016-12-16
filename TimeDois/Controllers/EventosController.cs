using System;
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
            var evento = new Evento
            {
                Nome = "Agile Trends",
                Descricao = "A Agile Trends é a principal conferência sobre tendências em agilidade do Brasil, reunindo os maiores especialistas e formadores de opinião da área.",
                DataInicio = new DateTime(2017, 04, 12),
                DataFim = new DateTime(2017, 04, 13),
                Endereco = new Endereco { Cidade = "São Paulo", Estado = "SP", Logradouro = "Av. Dr. Enéas de Carvalho Aguiar, 23" },
                ValorDeInscricao = 450.00m,
                Link = "http://agiletrendsbr.com/",
                UrlDaLogo = "http://agiletrendsbr.com/2014/wp-content/uploads/2014/02/logo-agiletrends-350x218.png"
            };
            return View(evento);
        }

        public ActionResult Participar(string eventoid)
        {
            throw new System.NotImplementedException();
        }
    }
}