using System;
using System.Data.Entity;
using System.Linq;
using TimeDois.Context;
using TimeDois.Models;

namespace TimeDois.Repositorio
{
    public class AvaliacaoRepository
    {
        private readonly Time2Entities _context;

        public AvaliacaoRepository()
        {
            _context = new Time2Entities();
        }

        public void Criar(Avaliacao entity)
        {
            _context.Avaliacoes.Add(entity);
            _context.SaveChanges();
        }

        public Avaliacao Obter(Func<Avaliacao, bool> expression)
        {
            return _context.Avaliacoes.FirstOrDefault(expression);
        }

        public IQueryable<Avaliacao> ObterTodos()
        {
            return _context.Avaliacoes;
        }

        public IQueryable<Avaliacao> ObterPor(Func<Avaliacao, bool> expression)
        {
            return _context.Avaliacoes.Where(expression).AsQueryable();
        }

        public void Atualizar(Avaliacao entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Avaliacao entity)
        {
            _context.Avaliacoes.Remove(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}