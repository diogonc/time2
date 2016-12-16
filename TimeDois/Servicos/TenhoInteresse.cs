using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeDois.Servicos
{
    public class TenhoInteresse
    {
        public void adicionar(Usuario usuario, Evento evento)
        {
            new Participacao(usuario, evento);
        }
    }
}