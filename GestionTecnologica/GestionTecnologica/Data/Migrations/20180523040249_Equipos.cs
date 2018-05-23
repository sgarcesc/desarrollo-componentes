using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GestionTecnologica.Data.Migrations
{
    public partial class Equipos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaCompra = table.Column<DateTime>(nullable: false),
                    FechaExpiracionGarantia = table.Column<DateTime>(nullable: false),
                    IdSede = table.Column<int>(nullable: false),
                    IdTipoEquipo = table.Column<int>(nullable: false),
                    NumeroSerie = table.Column<string>(nullable: false),
                    SedeId = table.Column<int>(nullable: true),
                    TipoEquipoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipo_Sede_SedeId",
                        column: x => x.SedeId,
                        principalTable: "Sede",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipo_TipoEquipo_TipoEquipoId",
                        column: x => x.TipoEquipoId,
                        principalTable: "TipoEquipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_SedeId",
                table: "Equipo",
                column: "SedeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_TipoEquipoId",
                table: "Equipo",
                column: "TipoEquipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipo");
        }
    }
}
