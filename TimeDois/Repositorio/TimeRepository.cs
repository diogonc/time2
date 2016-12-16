using System;
using System.Data.Entity;
using System.Linq;
using TimeDois.Context;
using TimeDois.Models;

namespace TimeDois.Repositorio
{
    public class TimeRepository
    {
        private readonly Time2Entities _context;

        public TimeRepository()
        {
            _context = new Time2Entities();
        }

        public void Criar(Time entity)
        {
            _context.Times.Add(entity);
            _context.SaveChanges();
        }

        public Time Obter(Func<Time, bool> expression)
        {
            return _context.Times.FirstOrDefault(expression);
        }

        public IQueryable<Time> ObterTodos()
        {
            return _context.Times;
        }

        public IQueryable<Time> ObterPor(Func<Time, bool> expression)
        {
            return _context.Times.Where(expression).AsQueryable();
        }

        public void Atualizar(Time entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Time entity)
        {
            _context.Times.Remove(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}