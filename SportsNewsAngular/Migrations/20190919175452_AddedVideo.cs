using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsNewsAngular.Migrations
{
    public partial class AddedVideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsShow = table.Column<bool>(nullable: false),
                    VideoUrl = table.Column<string>(nullable: true),
                    VideoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_Video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Video_VideoId",
                table: "Video",
                column: "VideoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Video");
        }
    }
}
