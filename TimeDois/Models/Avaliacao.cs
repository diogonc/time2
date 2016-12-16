using TimeDois.Models.Base;

namespace TimeDois.Models
{
    public class Avaliacao : Entidade
    {
        public bool Aprovado { get; set; }
        public string Justificativa { get; set; }
        public TipoDeAvaliacao TipoDeAvaliacao { get; set; }
        public virtual Participacao Participacao { get; set; }
        public virtual Usuario UsuarioQueAvaliou { get; set; }

        protected Avaliacao(){}

        public Avaliacao(Usuario usuarioQueAvaliou, bool aprovado, string justificativa)
        {
            Aprovado = aprovado;
            UsuarioQueAvaliou = usuarioQueAvaliou;
            Justificativa = justificativa;
            TipoDeAvaliacao = usuarioQueAvaliou.EhGerencia() ? TipoDeAvaliacao.Gerencia : TipoDeAvaliacao.Time;
        }
    }
}