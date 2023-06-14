using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursDB.Migrations
{
    /// <inheritdoc />
    public partial class DBErstellung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kurs",
                columns: table => new
                {
                    KursID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Raumnummer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurs", x => x.KursID);
                });

            migrationBuilder.CreateTable(
                name: "Studenten",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KursID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenten", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Studenten_Kurs_KursID",
                        column: x => x.KursID,
                        principalTable: "Kurs",
                        principalColumn: "KursID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Studenten_KursID",
                table: "Studenten",
                column: "KursID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studenten");

            migrationBuilder.DropTable(
                name: "Kurs");
        }
    }
}
