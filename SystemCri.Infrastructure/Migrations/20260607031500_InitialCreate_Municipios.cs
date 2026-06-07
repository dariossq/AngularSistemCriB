using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemCri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_Municipios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    MunicipioCod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipioNom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DeptoCod = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.MunicipioCod);
                    table.ForeignKey(
                        name: "FK_Municipios_Deptos_DeptoCod",
                        column: x => x.DeptoCod,
                        principalTable: "Deptos",
                        principalColumn: "DeptoCod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_DeptoCod",
                table: "Municipios",
                column: "DeptoCod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Municipios");
        }
    }
}
