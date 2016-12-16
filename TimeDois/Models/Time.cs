using System.Collections;
using System.Collections.Generic;

namespace TimeDois.Models
{
    public class Time
    {
        public int Id { get; set; }
        public string Nome { get; set; } 
        public IEnumerable<Usuario> Integrantes { get; set; }
    }
}