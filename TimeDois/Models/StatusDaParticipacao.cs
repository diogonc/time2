using System.ComponentModel;

namespace TimeDois.Models
{
    public enum StatusDaParticipacao
    {
        [Description("Aprovado")]
        Aprovado,
        [Description("Reprovado")]
        Reprovado,
        [Description("Em Análise")]
        EmAnalise
    }
}