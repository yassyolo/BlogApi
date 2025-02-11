using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogAPI.Migrations
{
    public partial class Streams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Joined",
                table: "ForumCommunities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date and time the community was created");

            migrationBuilder.AddColumn<string>(
                name: "RulesJson",
                table: "ForumCommunities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Rules of the community");

            migrationBuilder.CreateTable(
                name: "Streams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for the stream")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Name of the stream"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Description of the stream"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "URL handle for the stream"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Owner of the stream"),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    MaxViewers = table.Column<int>(type: "int", nullable: false, comment: "Max viewers count"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    When = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StreamKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreamUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Streams_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Streams_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Streams_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Stream entity");

            migrationBuilder.CreateTable(
                name: "UserStreams",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Primary key of the user stream"),
                    StreamId = table.Column<int>(type: "int", nullable: false, comment: "Primary key of the stream")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStreams", x => new { x.UserId, x.StreamId });
                    table.ForeignKey(
                        name: "FK_UserStreams_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStreams_Streams_StreamId",
                        column: x => x.StreamId,
                        principalTable: "Streams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4636df68-4850-474b-af65-8962c7a297ee", "AQAAAAEAACcQAAAAEJeM61+QThycFYSGZbt4xBC4+nphQVScfTkRrouSir7J+mkfWOXhm7vbVD/hrFsjmg==", "44a12be6-a3b4-4d94-8e1c-a9f01dc29dc6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c26b3ce1-89bf-4635-8408-4e0633f1d8fe", "AQAAAAEAACcQAAAAEKpikynx61Bm/Yej1laVBHeOumZN32yOj/L8IJMPSkt8F7RfnR9AJ9RMoCh5uYVl5A==", "5fe7a6a6-13d6-407c-804a-08dbd52db685" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "813ac317-88bd-439c-89b8-095f28d5dec1", "AQAAAAEAACcQAAAAED5Tgkmz/giTta+7Sr3kqj7WWANNh3iGHuB2kjbh1cNOcB1pgiCLkJufkMsE3TeOlA==", "6d95b247-9f66-4404-b583-f33e756bc023" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 2, 1, 10, 17, 48, 575, DateTimeKind.Utc).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 2, 3, 10, 17, 48, 575, DateTimeKind.Utc).AddTicks(9452));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 2, 5, 10, 17, 48, 575, DateTimeKind.Utc).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 2, 7, 10, 17, 48, 575, DateTimeKind.Utc).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2025, 2, 8, 10, 17, 48, 575, DateTimeKind.Utc).AddTicks(9457));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2025, 2, 9, 10, 17, 48, 575, DateTimeKind.Utc).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2025, 2, 10, 10, 17, 48, 575, DateTimeKind.Utc).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 11, 10, 17, 48, 576, DateTimeKind.Utc).AddTicks(960));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 11, 10, 17, 48, 576, DateTimeKind.Utc).AddTicks(961));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 11, 10, 17, 48, 576, DateTimeKind.Utc).AddTicks(962));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 11, 10, 17, 48, 576, DateTimeKind.Utc).AddTicks(963));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 11, 10, 17, 48, 576, DateTimeKind.Utc).AddTicks(964));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 11, 10, 17, 48, 576, DateTimeKind.Utc).AddTicks(965));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 11, 10, 17, 48, 576, DateTimeKind.Utc).AddTicks(965));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 11, 10, 17, 48, 576, DateTimeKind.Utc).AddTicks(966));

            migrationBuilder.UpdateData(
                table: "ForumCommunities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Joined", "RulesJson" },
                values: new object[] { new DateTime(2025, 2, 11, 10, 17, 48, 577, DateTimeKind.Utc).AddTicks(3950), "[\"Be respectful\",\"No spam\",\"Stay on topic\"]" });

            migrationBuilder.UpdateData(
                table: "ForumCommunities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Joined", "RulesJson" },
                values: new object[] { new DateTime(2025, 2, 11, 10, 17, 48, 577, DateTimeKind.Utc).AddTicks(3993), "[\"No misleading AI claims\",\"Credit sources\",\"Keep it professional\"]" });

            migrationBuilder.UpdateData(
                table: "ForumCommunities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Joined", "RulesJson" },
                values: new object[] { new DateTime(2025, 2, 11, 10, 17, 48, 577, DateTimeKind.Utc).AddTicks(4003), "[\"No game spoilers\",\"Respect hardware preferences\"]" });

            migrationBuilder.UpdateData(
                table: "ForumCommunities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Joined", "RulesJson" },
                values: new object[] { new DateTime(2025, 2, 11, 10, 17, 48, 577, DateTimeKind.Utc).AddTicks(4009), "[\"No fanboy wars\",\"Stay on gaming topics\"]" });

            migrationBuilder.UpdateData(
                table: "ForumCommunities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Joined", "RulesJson" },
                values: new object[] { new DateTime(2025, 2, 11, 10, 17, 48, 577, DateTimeKind.Utc).AddTicks(4015), "[\"Share verified resources\",\"No course piracy\"]" });

            migrationBuilder.UpdateData(
                table: "ForumCommunities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Joined", "RulesJson" },
                values: new object[] { new DateTime(2025, 2, 11, 10, 17, 48, 577, DateTimeKind.Utc).AddTicks(4020), "[\"No major spoilers\",\"Respect opinions\"]" });

            migrationBuilder.UpdateData(
                table: "ForumCommunities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Joined", "RulesJson" },
                values: new object[] { new DateTime(2025, 2, 11, 10, 17, 48, 577, DateTimeKind.Utc).AddTicks(4099), "[\"Stay scientific\",\"No conspiracy theories\"]" });

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 10, 17, 48, 577, DateTimeKind.Utc).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 10, 17, 48, 577, DateTimeKind.Utc).AddTicks(8002));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 10, 17, 48, 577, DateTimeKind.Utc).AddTicks(8004));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 10, 17, 48, 577, DateTimeKind.Utc).AddTicks(8005));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 10, 17, 48, 577, DateTimeKind.Utc).AddTicks(8006));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 10, 17, 48, 577, DateTimeKind.Utc).AddTicks(8007));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 10, 17, 48, 577, DateTimeKind.Utc).AddTicks(8008));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 11, 10, 17, 48, 577, DateTimeKind.Utc).AddTicks(8009));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2613));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2617));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2620));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2622));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2625));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2628));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2633));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2636));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2639));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2641));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2649));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2651));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2654));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2656));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2659));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateCreated",
                value: new DateTime(2025, 2, 11, 12, 17, 48, 576, DateTimeKind.Local).AddTicks(2661));

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 1, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "AchievementDate",
                value: new DateTime(2025, 2, 1, 10, 17, 48, 576, DateTimeKind.Utc).AddTicks(8600));

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 4, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "AchievementDate",
                value: new DateTime(2025, 2, 5, 10, 17, 48, 576, DateTimeKind.Utc).AddTicks(8603));

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 7, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "AchievementDate",
                value: new DateTime(2025, 2, 9, 10, 17, 48, 576, DateTimeKind.Utc).AddTicks(8605));

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 10, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "AchievementDate",
                value: new DateTime(2025, 2, 3, 10, 17, 48, 576, DateTimeKind.Utc).AddTicks(8607));

            migrationBuilder.UpdateData(
                table: "VisitedForumCommunities",
                keyColumns: new[] { "ForumCommunityId", "UserId" },
                keyValues: new object[] { 1, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "LastVisited",
                value: new DateTime(2025, 2, 9, 10, 17, 48, 578, DateTimeKind.Utc).AddTicks(425));

            migrationBuilder.UpdateData(
                table: "VisitedForumCommunities",
                keyColumns: new[] { "ForumCommunityId", "UserId" },
                keyValues: new object[] { 2, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "LastVisited",
                value: new DateTime(2025, 2, 9, 10, 17, 48, 578, DateTimeKind.Utc).AddTicks(426));

            migrationBuilder.CreateIndex(
                name: "IX_Streams_CategoryId",
                table: "Streams",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Streams_ImageId",
                table: "Streams",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Streams_OwnerId",
                table: "Streams",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStreams_StreamId",
                table: "UserStreams",
                column: "StreamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserStreams");

            migrationBuilder.DropTable(
                name: "Streams");

            migrationBuilder.DropColumn(
                name: "Joined",
                table: "ForumCommunities");

            migrationBuilder.DropColumn(
                name: "RulesJson",
                table: "ForumCommunities");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4984cee-fcf2-43b2-9c70-3ec759b7d612", "AQAAAAEAACcQAAAAENrwlIU3bbftSkQBjo1B3t464nbyDDvzHQWIG4JIZRs+sxL2JrTsHoHaR3QBoc2Mtg==", "54da6ee6-76b4-4bd6-97bc-467588639d56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b626fe0-124a-406a-ab40-32514c11fdee", "AQAAAAEAACcQAAAAEM45271WW1WyT/MWPyqWAvraZU6ECdr+ADQKTVuCpzMLAbaVBce6tntq7R2gE2v1ZQ==", "a41bd303-8cc6-4fa4-8e3f-a4ce97ea3d33" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8afc659f-70d9-4830-a3e7-e191bb3b68d8", "AQAAAAEAACcQAAAAEHX1XWRfjhlo7XFf1b1Dsg0oXeWM7WzjDg5PmhHQmfW4LF5NhIG6S01uN5124xjpSg==", "8a06c0e0-aadc-44bf-9746-f97add32d47a" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 1, 30, 10, 56, 7, 348, DateTimeKind.Utc).AddTicks(6809));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 2, 1, 10, 56, 7, 348, DateTimeKind.Utc).AddTicks(6812));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 2, 3, 10, 56, 7, 348, DateTimeKind.Utc).AddTicks(6814));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 2, 5, 10, 56, 7, 348, DateTimeKind.Utc).AddTicks(6815));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2025, 2, 6, 10, 56, 7, 348, DateTimeKind.Utc).AddTicks(6817));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2025, 2, 7, 10, 56, 7, 348, DateTimeKind.Utc).AddTicks(6818));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2025, 2, 8, 10, 56, 7, 348, DateTimeKind.Utc).AddTicks(6820));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 9, 10, 56, 7, 348, DateTimeKind.Utc).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 9, 10, 56, 7, 348, DateTimeKind.Utc).AddTicks(7997));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 9, 10, 56, 7, 348, DateTimeKind.Utc).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 9, 10, 56, 7, 348, DateTimeKind.Utc).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 9, 10, 56, 7, 348, DateTimeKind.Utc).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 9, 10, 56, 7, 348, DateTimeKind.Utc).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 9, 10, 56, 7, 348, DateTimeKind.Utc).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 9, 10, 56, 7, 348, DateTimeKind.Utc).AddTicks(8001));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 9, 10, 56, 7, 350, DateTimeKind.Utc).AddTicks(1338));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 9, 10, 56, 7, 350, DateTimeKind.Utc).AddTicks(1339));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 9, 10, 56, 7, 350, DateTimeKind.Utc).AddTicks(1341));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 9, 10, 56, 7, 350, DateTimeKind.Utc).AddTicks(1342));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 9, 10, 56, 7, 350, DateTimeKind.Utc).AddTicks(1343));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 9, 10, 56, 7, 350, DateTimeKind.Utc).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 9, 10, 56, 7, 350, DateTimeKind.Utc).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 9, 10, 56, 7, 350, DateTimeKind.Utc).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9327));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9329));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9339));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9342));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9347));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9349));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9352));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9354));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9357));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9361));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9364));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9366));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateCreated",
                value: new DateTime(2025, 2, 9, 12, 56, 7, 348, DateTimeKind.Local).AddTicks(9369));

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 1, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "AchievementDate",
                value: new DateTime(2025, 1, 30, 10, 56, 7, 349, DateTimeKind.Utc).AddTicks(4379));

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 4, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "AchievementDate",
                value: new DateTime(2025, 2, 3, 10, 56, 7, 349, DateTimeKind.Utc).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 7, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "AchievementDate",
                value: new DateTime(2025, 2, 7, 10, 56, 7, 349, DateTimeKind.Utc).AddTicks(4383));

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 10, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "AchievementDate",
                value: new DateTime(2025, 2, 1, 10, 56, 7, 349, DateTimeKind.Utc).AddTicks(4385));

            migrationBuilder.UpdateData(
                table: "VisitedForumCommunities",
                keyColumns: new[] { "ForumCommunityId", "UserId" },
                keyValues: new object[] { 1, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "LastVisited",
                value: new DateTime(2025, 2, 7, 10, 56, 7, 350, DateTimeKind.Utc).AddTicks(3208));

            migrationBuilder.UpdateData(
                table: "VisitedForumCommunities",
                keyColumns: new[] { "ForumCommunityId", "UserId" },
                keyValues: new object[] { 2, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "LastVisited",
                value: new DateTime(2025, 2, 7, 10, 56, 7, 350, DateTimeKind.Utc).AddTicks(3209));
        }
    }
}
