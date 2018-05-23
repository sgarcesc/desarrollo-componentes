using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GestionTecnologica.Data.Migrations
{
    public partial class sede : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudad_Departamento_DepartamentoIdDepartameto",
                table: "Ciudad");

            migrationBuilder.DropIndex(
                name: "IX_Ciudad_DepartamentoIdDepartameto",
                table: "Ciudad");

            migrationBuilder.DropColumn(
                name: "DepartamentoIdDepartameto",
                table: "Ciudad");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Sede",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Sede",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_IdDepartamento",
                table: "Ciudad",
                column: "IdDepartamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudad_Departamento_IdDepartamento",
                table: "Ciudad",
                column: "IdDepartamento",
                principalTable: "Departamento",
                principalColumn: "IdDepartameto",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudad_Departamento_IdDepartamento",
                table: "Ciudad");

            migrationBuilder.DropIndex(
                name: "IX_Ciudad_IdDepartamento",
                table: "Ciudad");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Sede");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Sede",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoIdDepartameto",
                table: "Ciudad",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_DepartamentoIdDepartameto",
                table: "Ciudad",
                column: "DepartamentoIdDepartameto");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudad_Departamento_DepartamentoIdDepartameto",
                table: "Ciudad",
                column: "DepartamentoIdDepartameto",
                principalTable: "Departamento",
                principalColumn: "IdDepartameto",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
