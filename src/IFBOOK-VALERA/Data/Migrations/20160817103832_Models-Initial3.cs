using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IFBOOK_VALERA.Data.Migrations
{
    public partial class ModelsInitial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FKUsuarioId",
                table: "Publicacoes");

            migrationBuilder.DropColumn(
                name: "FKUsuarioId",
                table: "Comentarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FKUsuarioId",
                table: "Publicacoes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FKUsuarioId",
                table: "Comentarios",
                nullable: false,
                defaultValue: "");
        }
    }
}
