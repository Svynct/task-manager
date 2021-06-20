using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskManager_WebAPI.Models;

namespace TaskManager_WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges()) > 0;
        }
        public Tarefa[] GetTarefas()
        {
            return _context.Tarefas.AsNoTracking().OrderBy(t => t.Id).ToArray();
        }
        public Tarefa GetTarefasById(int tarefaId)
        {
            return _context.Tarefas.AsNoTracking().FirstOrDefault(tarefa => tarefa.Id == tarefaId);
        }
        public Usuario[] GetUsuarios()
        {
            return _context.Usuarios.AsNoTracking().OrderBy(u => u.Id).ToArray();
        }
        public Usuario GetUsuarioById(int usuarioId)
        {
            return _context.Usuarios.AsNoTracking().FirstOrDefault(usuario => usuario.Id == usuarioId);
        }
    }
}