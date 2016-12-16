using TimeDois.Models.Base;

namespace TimeDois.Models
{
    public class Avaliacao : Entidade
    {
        public bool Aprovado { get; set; }
        public Usuario UsuarioQueAvaliou { get; set; }
        public string Justificativa { get; set; }
        public TipoDeAvaliacao TipoDeAvaliacao { get; set; }
        public virtual Participacao Participacao { get; set; }
    }
}