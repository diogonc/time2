using System;
using System.Data.Entity;
using System.Linq;
using TimeDois.Context;
using TimeDois.Models;

namespace TimeDois.Repositorio
{
    public class ParticipacaoRepository
    {
        private readonly Time2Entities _context;

        public ParticipacaoRepository(Time2Entities contexto)
        {
            _context = contexto;
        }

        public void Criar(Participacao entity)
        {
            _context.Participacoes.Add(entity);
            _context.SaveChanges();
        }

        public Participacao Obter(Func<Participacao, bool> expression)
        {
            return _context.Participacoes.FirstOrDefault(expression);
        }

        public IQueryable<Participacao> ObterTodos()
        {
            return _context.Participacoes;
        }

        public IQueryable<Participacao> ObterPor(Func<Participacao, bool> expression)
        {
            return _context.Participacoes.Where(expression).AsQueryable();
        }

        public void Atualizar(Participacao entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Participacao entity)
        {
            _context.Participacoes.Remove(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}