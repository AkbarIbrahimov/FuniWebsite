using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Funi.Migrations
{
    /// <inheritdoc />
    public partial class CreateDesignTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Designs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageOne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageTwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageThree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subtitle4 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Designs");
        }
    }
}
