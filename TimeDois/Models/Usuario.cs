using System.Collections.Generic;
using TimeDois.Models.Base;

namespace TimeDois.Models
{
    public class Usuario : Entidade
    {
        public Usuario()
        {
            Avaliacoes = new List<Avaliacao>();
        }

        public Usuario(string login, string senha)
        {
            Login = login;
            Senha = senha;
            Avaliacoes = new List<Avaliacao>();
        }

        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public GrupoDeUsuario GrupoDeUsuario { get; set; }
        public virtual Time Time { get; set; }
        
        public virtual ICollection<Participacao> Participacoes { get; set; }
        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }

        public virtual bool EhGerencia()
        {
            return GrupoDeUsuario == GrupoDeUsuario.Gerencia;
        }
    }
}