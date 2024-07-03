using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jocksWebApp.Migrations
{
    /// <inheritdoc />
    public partial class EditQAnswerConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "joke");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "joke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jokeAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    jokeQustion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_joke", x => x.Id);
                });
        }
    }
}
