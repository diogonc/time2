using System;
using System.Data.Entity;
using System.Linq;
using TimeDois.Context;
using TimeDois.Models;

namespace TimeDois.Repositorio
{
    public class UsuarioRepository
    {
        private readonly Time2Entities _context;

        public UsuarioRepository()
        {
            _context = new Time2Entities();
        }

        public void Criar(Usuario entity)
        {
            _context.Usuarios.Add(entity);
            _context.SaveChanges();
        }

        public Usuario Obter(Func<Usuario, bool> expression)
        {
            return _context.Usuarios.FirstOrDefault(expression);
        }

        public IQueryable<Usuario> ObterTodos()
        {
            return _context.Usuarios;
        }

        public IQueryable<Usuario> ObterPor(Func<Usuario, bool> expression)
        {
            return _context.Usuarios.Where(expression).AsQueryable();
        }

        public void Atualizar(Usuario entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Usuario entity)
        {
            _context.Usuarios.Remove(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}