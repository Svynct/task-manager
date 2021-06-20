using TaskManager_WebAPI.Models;

namespace TaskManager_WebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();
        Usuario[] GetUsuarios();
        Usuario GetUsuarioById(int usuarioId);
        Tarefa[] GetTarefas();
        Tarefa GetTarefasById(int tarefaId);
    }
}