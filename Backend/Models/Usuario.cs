using System.Collections.Generic;

namespace TaskManager_WebAPI.Models
{
    public class Usuario
    {
        public Usuario()
        {
            this.Tarefas = new List<Tarefa>();
        }
        public Usuario(int id, string nome, string email, string senha, string permissao)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.Permissao = permissao;
            this.Tarefas = new List<Tarefa>();
        }
        public void inserirTarefa(Tarefa T)
        {
            Tarefas.Add(T);
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Permissao { get; set; }
        public List<Tarefa> Tarefas { get; }
    }
}