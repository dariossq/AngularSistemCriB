using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemCri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeTuMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioLogo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UsuarioPie = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UsuarioEtnia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioDepartamento = table.Column<int>(type: "int", nullable: true),
                    UsuarioMunicipio = table.Column<int>(type: "int", nullable: true),
                    UsuarioEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Deptos_UsuarioDepartamento",
                        column: x => x.UsuarioDepartamento,
                        principalTable: "Deptos",
                        principalColumn: "DeptoCod",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Municipios_UsuarioMunicipio",
                        column: x => x.UsuarioMunicipio,
                        principalTable: "Municipios",
                        principalColumn: "MunicipioCod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioDepartamento",
                table: "Usuarios",
                column: "UsuarioDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UsuarioMunicipio",
                table: "Usuarios",
                column: "UsuarioMunicipio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
