using System;
using System.Data.Entity;
using System.Linq;
using TimeDois.Context;
using TimeDois.Models;

namespace TimeDois.Repositorio
{
    public class EventoRepository
    {
        private readonly Time2Entities _context;

        public EventoRepository()
        {
            _context = new Time2Entities();
        }

        public void Criar(Evento entity)
        {
            _context.Eventos.Add(entity);
            _context.SaveChanges();
        }

        public Evento Obter(Func<Evento, bool> expression)
        {
            return _context.Eventos.FirstOrDefault(expression);
        }

        public IQueryable<Evento> ObterTodos()
        {
            return _context.Eventos;
        }

        public IQueryable<Evento> ObterPor(Func<Evento, bool> expression)
        {
            return _context.Eventos.Where(expression).AsQueryable();
        }

        public void Atualizar(Evento entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Evento entity)
        {
            _context.Eventos.Remove(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}