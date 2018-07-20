using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tweets.DataAccess.Migrations
{
    public partial class tweets001init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eTweetsCollections",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eTweetsCollections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "eTweets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    TweetsCollectionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eTweets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_eTweets_eTweetsCollections_TweetsCollectionId",
                        column: x => x.TweetsCollectionId,
                        principalTable: "eTweetsCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_eTweets_TweetsCollectionId",
                table: "eTweets",
                column: "TweetsCollectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eTweets");

            migrationBuilder.DropTable(
                name: "eTweetsCollections");
        }
    }
}
