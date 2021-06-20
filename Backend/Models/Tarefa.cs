namespace TaskManager_WebAPI.Models
{
    public class Tarefa
    {
        public Tarefa()
        {
            this.Concluida = false;
        }
        public Tarefa(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;       
            this.Concluida = false;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Concluida { get; set; }
    }
}