using System;
using System.Data.Entity;
using System.Linq;
using TimeDois.Context;
using TimeDois.Models;

namespace TimeDois.Repositorio
{
    public class EnderecoRepository
    {
        private readonly Time2Entities _context;

        public EnderecoRepository()
        {
            _context = new Time2Entities();
        }

        public void Criar(Endereco entity)
        {
            _context.Enderecos.Add(entity);
            _context.SaveChanges();
        }

        public Endereco Obter(Func<Endereco, bool> expression)
        {
            return _context.Enderecos.FirstOrDefault(expression);
        }

        public IQueryable<Endereco> ObterTodos()
        {
            return _context.Enderecos;
        }

        public IQueryable<Endereco> ObterPor(Func<Endereco, bool> expression)
        {
            return _context.Enderecos.Where(expression).AsQueryable();
        }

        public void Atualizar(Endereco entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Endereco entity)
        {
            _context.Enderecos.Remove(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}