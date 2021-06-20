using System.Collections.Generic;

namespace TaskManager_WebAPI.Models
{
    public class UsuarioTarefa
    {
        public UsuarioTarefa() { }
        public UsuarioTarefa(int usuarioId, int tarefaId)
        {
            UsuarioId = usuarioId;
            TarefaId = tarefaId;
        }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int TarefaId { get; set; }
        public List<Tarefa> Tarefas { get; set; }
    }
}