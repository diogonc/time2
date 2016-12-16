using TimeDois.Models.Base;

namespace TimeDois.Models
{
    public class Endereco : Entidade
    {
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public override string ToString()
        {
            return Logradouro + ", " + Cidade + " - " + Estado;
        }
        public virtual Evento Evento { get; set; }
    }
}