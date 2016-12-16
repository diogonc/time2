using System.Reflection.Emit;
using TimeDois.Extensoes;

namespace TimeDois.ViewModel
{
    public class OrcamentoViewModel
    {
        public decimal ValorUtilizado { get; set; }
        public decimal ValorDisponivel { get; set; }
        public decimal PorcertagemUtilizada { get { return ValorUtilizado.ObterPercentual(ValorDisponivel); } } 
        public string ClasseDaBarra { get { return PorcertagemUtilizada > 50m ? PorcertagemUtilizada > 75m ? "is-danger" : "is-warning" : "is-info"; } }
    }
}