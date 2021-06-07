using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularCaseStudy.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoriesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoriesID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Query",
                columns: table => new
                {
                    QueryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QContent = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    SContent = table.Column<string>(nullable: true),
                    References = table.Column<string>(nullable: true),
                    UserofQueryEmployeeID = table.Column<int>(nullable: false),
                    CategoryCategoriesID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Query", x => x.QueryID);
                    table.ForeignKey(
                        name: "FK_Query_Categories_CategoryCategoriesID",
                        column: x => x.CategoryCategoriesID,
                        principalTable: "Categories",
                        principalColumn: "CategoriesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Query_Employee_UserofQueryEmployeeID",
                        column: x => x.UserofQueryEmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solution",
                columns: table => new
                {
                    SolutionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sContent = table.Column<string>(nullable: false),
                    references = table.Column<string>(nullable: true),
                    SolutionForQueryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solution", x => x.SolutionID);
                    table.ForeignKey(
                        name: "FK_Solution_Query_SolutionForQueryID",
                        column: x => x.SolutionForQueryID,
                        principalTable: "Query",
                        principalColumn: "QueryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Query_CategoryCategoriesID",
                table: "Query",
                column: "CategoryCategoriesID");

            migrationBuilder.CreateIndex(
                name: "IX_Query_UserofQueryEmployeeID",
                table: "Query",
                column: "UserofQueryEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Solution_SolutionForQueryID",
                table: "Solution",
                column: "SolutionForQueryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solution");

            migrationBuilder.DropTable(
                name: "Query");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
