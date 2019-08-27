using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportNews.Data.Migrations
{
    public partial class ArticleDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "secondNavigationMenus");

            migrationBuilder.DropTable(
                name: "mainNavigationMenus");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsShow = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categoryUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsShow = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categoryUsers_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categoryUsers_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "divisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsShow = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 15, nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_divisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_divisions_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsShow = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 15, nullable: true),
                    DivisonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teams_divisions_DivisonId",
                        column: x => x.DivisonId,
                        principalTable: "divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsShow = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: true),
                    CategoryID = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 45, nullable: true),
                    Text = table.Column<string>(maxLength: 255, nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_articles_categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articles_teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_articles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsShow = table.Column<bool>(nullable: false),
                    Text = table.Column<string>(maxLength: 155, nullable: true),
                    ArticleId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comments_articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_articles_CategoryID",
                table: "articles",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_articles_TeamId",
                table: "articles",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_articles_UserId",
                table: "articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_categoryUsers_CategoryId",
                table: "categoryUsers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_categoryUsers_UserId1",
                table: "categoryUsers",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_comments_ArticleId",
                table: "comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_UserId",
                table: "comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_divisions_CategoryId",
                table: "divisions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_teams_DivisonId",
                table: "teams",
                column: "DivisonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categoryUsers");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "articles");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "divisions");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "mainNavigationMenus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsShow = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: true),
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
                    MainNavigationMenuId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: true),
                    Order = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_secondNavigationMenus_MainNavigationMenuId",
                table: "secondNavigationMenus",
                column: "MainNavigationMenuId");
        }
    }
}
