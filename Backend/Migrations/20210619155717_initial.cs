using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager_WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Senha = table.Column<string>(type: "TEXT", nullable: true),
                    Permissao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosTarefas",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    TarefaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosTarefas", x => new { x.UsuarioId, x.TarefaId });
                    table.ForeignKey(
                        name: "FK_UsuariosTarefas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Concluida = table.Column<bool>(type: "INTEGER", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: true),
                    UsuarioTarefaTarefaId = table.Column<int>(type: "INTEGER", nullable: true),
                    UsuarioTarefaUsuarioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarefas_UsuariosTarefas_UsuarioTarefaUsuarioId_UsuarioTarefaTarefaId",
                        columns: x => new { x.UsuarioTarefaUsuarioId, x.UsuarioTarefaTarefaId },
                        principalTable: "UsuariosTarefas",
                        principalColumns: new[] { "UsuarioId", "TarefaId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "Id", "Concluida", "Nome", "UsuarioId", "UsuarioTarefaTarefaId", "UsuarioTarefaUsuarioId" },
                values: new object[] { 1, false, "Reunião com Gestor", null, null, null });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "Id", "Concluida", "Nome", "UsuarioId", "UsuarioTarefaTarefaId", "UsuarioTarefaUsuarioId" },
                values: new object[] { 2, false, "Ligar para Prestador de Serviço", null, null, null });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "Id", "Concluida", "Nome", "UsuarioId", "UsuarioTarefaTarefaId", "UsuarioTarefaUsuarioId" },
                values: new object[] { 3, false, "Responder email do Cliente", null, null, null });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "Id", "Concluida", "Nome", "UsuarioId", "UsuarioTarefaTarefaId", "UsuarioTarefaUsuarioId" },
                values: new object[] { 4, false, "Ler comunicado da Empresa", null, null, null });

            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "Id", "Concluida", "Nome", "UsuarioId", "UsuarioTarefaTarefaId", "UsuarioTarefaUsuarioId" },
                values: new object[] { 5, false, "Realizar Inventário", null, null, null });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Nome", "Permissao", "Senha" },
                values: new object[] { 1, "admin@admin.com", "admin", "Administrador", "admin" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Nome", "Permissao", "Senha" },
                values: new object[] { 2, "carlos@gmail.com", "Carlos", "Usuário", "123456" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Nome", "Permissao", "Senha" },
                values: new object[] { 3, "sergio@gmail.com", "Sérgio", "Usuário", "sergio@40" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Nome", "Permissao", "Senha" },
                values: new object[] { 4, "jose@gmail.com", "José", "Usuário", "j123456" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Nome", "Permissao", "Senha" },
                values: new object[] { 5, "maria@gmail.com", "Maria", "Usuário", "maria#20" });

            migrationBuilder.InsertData(
                table: "UsuariosTarefas",
                columns: new[] { "TarefaId", "UsuarioId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "UsuariosTarefas",
                columns: new[] { "TarefaId", "UsuarioId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "UsuariosTarefas",
                columns: new[] { "TarefaId", "UsuarioId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "UsuariosTarefas",
                columns: new[] { "TarefaId", "UsuarioId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "UsuariosTarefas",
                columns: new[] { "TarefaId", "UsuarioId" },
                values: new object[] { 5, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_UsuarioId",
                table: "Tarefas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_UsuarioTarefaUsuarioId_UsuarioTarefaTarefaId",
                table: "Tarefas",
                columns: new[] { "UsuarioTarefaUsuarioId", "UsuarioTarefaTarefaId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "UsuariosTarefas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
