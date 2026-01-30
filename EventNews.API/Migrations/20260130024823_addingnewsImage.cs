using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventNews.API.Migrations
{
    public partial class addingnewsImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "News");

            migrationBuilder.CreateTable(
                name: "news_images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NewsId = table.Column<long>(type: "bigint", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news_images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_news_images_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_news_images_NewsId",
                table: "news_images",
                column: "NewsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "news_images");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "News",
                type: "text",
                nullable: true);
        }
    }
}
