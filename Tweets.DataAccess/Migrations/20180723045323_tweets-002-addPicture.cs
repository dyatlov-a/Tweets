using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tweets.DataAccess.Migrations
{
    public partial class tweets002addPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ePictures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    TweetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ePictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ePictures_eTweets_TweetId",
                        column: x => x.TweetId,
                        principalTable: "eTweets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ePictures_TweetId",
                table: "ePictures",
                column: "TweetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ePictures");
        }
    }
}
