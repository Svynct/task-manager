using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TaskManager_WebAPI.Models;

namespace TaskManager_WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<UsuarioTarefa> UsuariosTarefas { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UsuarioTarefa>()
                .HasKey(UT => new { UT.UsuarioId, UT.TarefaId });

            builder.Entity<Tarefa>()
                .HasData(new List<Tarefa>(){
                    new Tarefa(1, "Reunião com Gestor"),
                    new Tarefa(2, "Ligar para Prestador de Serviço"),
                    new Tarefa(3, "Responder email do Cliente"),
                    new Tarefa(4, "Ler comunicado da Empresa"),
                    new Tarefa(5, "Realizar Inventário"),
                });

            builder.Entity<Usuario>()
                .HasData(new List<Usuario>(){
                    new Usuario(1, "admin", "admin@admin.com", "admin", "Administrador"),
                    new Usuario(2, "Carlos", "carlos@gmail.com", "123456", "Usuário"),
                    new Usuario(3, "Sérgio", "sergio@gmail.com", "sergio@40", "Usuário"),
                    new Usuario(4, "José", "jose@gmail.com", "j123456", "Usuário"),
                    new Usuario(5, "Maria", "maria@gmail.com", "maria#20", "Usuário"),
                });

            builder.Entity<UsuarioTarefa>()
                .HasData(new List<UsuarioTarefa>() {
                    new UsuarioTarefa() {UsuarioId = 1, TarefaId = 1 },
                    new UsuarioTarefa() {UsuarioId = 2, TarefaId = 2 },
                    new UsuarioTarefa() {UsuarioId = 3, TarefaId = 3 },
                    new UsuarioTarefa() {UsuarioId = 4, TarefaId = 4 },
                    new UsuarioTarefa() {UsuarioId = 5, TarefaId = 5 }
                });
        }
    }
}