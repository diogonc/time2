using System.Collections;
using System.Collections.Generic;

namespace TimeDois.Models
{
    public class Time
    {
        public string Nome { get; set; } 
        public IEnumerable<Usuario> Integrantes { get; set; }
    }
}