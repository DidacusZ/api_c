using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api4.Migrations
{
    /// <inheritdoc />
    public partial class _1m : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accesos",
                columns: table => new
                {
                    id_acceso = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigo_acceso = table.Column<string>(type: "text", nullable: false),
                    descripcion_acceso = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesos", x => x.id_acceso);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dni_usuario = table.Column<string>(type: "text", nullable: false),
                    nombre_usuario = table.Column<string>(type: "text", nullable: false),
                    apellidos_usuario = table.Column<string>(type: "text", nullable: false),
                    tlf_usuario = table.Column<string>(type: "text", nullable: false),
                    email_usuario = table.Column<string>(type: "text", nullable: false),
                    clave_usuario = table.Column<string>(type: "text", nullable: false),
                    id_acceso = table.Column<int>(type: "integer", nullable: false),
                    estaBloqueado_usuario = table.Column<bool>(type: "boolean", nullable: false),
                    fch_fin_bloqueo_usuario = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fch_alta_usuario = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fch_baja_usuario = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Accesos_id_acceso",
                        column: x => x.id_acceso,
                        principalTable: "Accesos",
                        principalColumn: "id_acceso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_id_acceso",
                table: "Usuarios",
                column: "id_acceso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Accesos");
        }
    }
}
