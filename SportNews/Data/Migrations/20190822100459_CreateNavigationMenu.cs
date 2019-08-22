using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportNews.Data.Migrations
{
    public partial class CreateNavigationMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mainNavigationMenus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsShow = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mainNavigationMenus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "secondNavigationMenus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsShow = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    MainNavigationMenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_secondNavigationMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_secondNavigationMenus_mainNavigationMenus_MainNavigationMenuId",
                        column: x => x.MainNavigationMenuId,
                        principalTable: "mainNavigationMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "thirdNavigationMenus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsShow = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    SecondNavigationMenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thirdNavigationMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_thirdNavigationMenus_secondNavigationMenus_SecondNavigationMenuId",
                        column: x => x.SecondNavigationMenuId,
                        principalTable: "secondNavigationMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_secondNavigationMenus_MainNavigationMenuId",
                table: "secondNavigationMenus",
                column: "MainNavigationMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_thirdNavigationMenus_SecondNavigationMenuId",
                table: "thirdNavigationMenus",
                column: "SecondNavigationMenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "thirdNavigationMenus");

            migrationBuilder.DropTable(
                name: "secondNavigationMenus");

            migrationBuilder.DropTable(
                name: "mainNavigationMenus");
        }
    }
}
