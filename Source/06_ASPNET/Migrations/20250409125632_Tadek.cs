using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _06_ASPNET.Migrations
{
    /// <inheritdoc />
    public partial class Tadek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BMIId",
                table: "Uzivatele",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BmiModely",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vyska = table.Column<double>(type: "float", nullable: false),
                    Vaha = table.Column<double>(type: "float", nullable: false),
                    BmiVysledek = table.Column<double>(type: "float", nullable: true),
                    BmiKategorie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BmiModely", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uzivatele_BMIId",
                table: "Uzivatele",
                column: "BMIId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uzivatele_BmiModely_BMIId",
                table: "Uzivatele",
                column: "BMIId",
                principalTable: "BmiModely",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzivatele_BmiModely_BMIId",
                table: "Uzivatele");

            migrationBuilder.DropTable(
                name: "BmiModely");

            migrationBuilder.DropIndex(
                name: "IX_Uzivatele_BMIId",
                table: "Uzivatele");

            migrationBuilder.DropColumn(
                name: "BMIId",
                table: "Uzivatele");
        }
    }
}
