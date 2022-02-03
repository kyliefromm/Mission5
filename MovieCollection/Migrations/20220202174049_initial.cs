using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCollection.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    Lent = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.MovieID);
                    table.ForeignKey(
                        name: "FK_Responses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Action" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "Comedy" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Drama" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 4, "Mystery" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 5, "Romance" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "MovieID", "CategoryId", "Director", "Edited", "Lent", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, 1, "Jon Watts", false, " ", "Love this show so much!", "PG-13", "Spider Man No Way Home", 2021 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "MovieID", "CategoryId", "Director", "Edited", "Lent", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, 3, "Jon M. Chu", false, " ", "Love this show so much!", "PG-13", "In the Heights", 2021 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "MovieID", "CategoryId", "Director", "Edited", "Lent", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, 5, "Andy Tennant", false, " ", "Love this show so much!", "PG-13", "Hitch", 2005 });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_CategoryId",
                table: "Responses",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
