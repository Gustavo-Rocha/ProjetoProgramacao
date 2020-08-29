using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agendamento.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    cpf = table.Column<double>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Celular = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.cpf);
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    Data = table.Column<DateTime>(nullable: false),
                    clientecpf = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.Data);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Clientes_clientecpf",
                        column: x => x.clientecpf,
                        principalTable: "Clientes",
                        principalColumn: "cpf",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_clientecpf",
                table: "Agendamentos",
                column: "clientecpf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
