namespace TimeDois.Models
{
    public class Avaliacao
    {
        public bool Aprovado { get; set; }
        public Usuario UsuarioQueAvaliou { get; set; }
        public string Justificativa { get; set; }
        public TipoDeAvaliacao TipoDeAvaliacao { get; set; }
    }
}