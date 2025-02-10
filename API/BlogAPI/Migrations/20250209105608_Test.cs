using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogAPI.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ForumCommunityId",
                table: "Images",
                type: "int",
                nullable: true,
                comment: "The forum comment identifier.");

            migrationBuilder.CreateTable(
                name: "VisitedForumCommunities",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Id of the user visited forum community"),
                    ForumCommunityId = table.Column<int>(type: "int", nullable: false, comment: "Id of the forum community visited by the user"),
                    LastVisited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitedForumCommunities", x => new { x.UserId, x.ForumCommunityId });
                    table.ForeignKey(
                        name: "FK_VisitedForumCommunities_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitedForumCommunities_ForumCommunities_ForumCommunityId",
                        column: x => x.ForumCommunityId,
                        principalTable: "ForumCommunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Visited forum community entity");

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

            migrationBuilder.InsertData(
                table: "VisitedForumCommunities",
                columns: new[] { "ForumCommunityId", "UserId", "LastVisited", "Visits" },
                values: new object[,]
                {
                    { 1, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", new DateTime(2025, 2, 7, 10, 56, 7, 350, DateTimeKind.Utc).AddTicks(3208), 4 },
                    { 2, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", new DateTime(2025, 2, 7, 10, 56, 7, 350, DateTimeKind.Utc).AddTicks(3209), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ForumCommunityId",
                table: "Images",
                column: "ForumCommunityId",
                unique: true,
                filter: "[ForumCommunityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VisitedForumCommunities_ForumCommunityId",
                table: "VisitedForumCommunities",
                column: "ForumCommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_ForumCommunities_ForumCommunityId",
                table: "Images",
                column: "ForumCommunityId",
                principalTable: "ForumCommunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_ForumCommunities_ForumCommunityId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "VisitedForumCommunities");

            migrationBuilder.DropIndex(
                name: "IX_Images_ForumCommunityId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ForumCommunityId",
                table: "Images");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25f15b55-dd91-47c4-938d-1912b3d4f008", "AQAAAAEAACcQAAAAELGN8z5FCa0Hh760WSBNymxcKMbMBLPwJnhUlqsEY6D+XmApe0+5zmAMN/saihVE3A==", "1c5eb1c7-0e70-4959-b39f-66574a645266" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc2e3c31-87ce-4ff9-961c-1654e0b3dd52", "AQAAAAEAACcQAAAAELrIAiMp7RvmkIlCxDuh635xN1IRVWcMiJpGSXXBM/92p0mbkl2T/93J8ydgts39Gw==", "656cd90a-08c6-4f22-959a-1edf2bdc6a0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b22d6187-f04a-4f6d-991b-475cc01958a4", "AQAAAAEAACcQAAAAEL0KQRTj4dzlw8VyBpZ7sL1fW3etOA9OYHkZvOHmMIo29zCzascaKuIHq1wA6I8Zag==", "70aba5bf-0f37-471d-9811-d4b3a2945904" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 1, 29, 14, 22, 42, 913, DateTimeKind.Utc).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 1, 31, 14, 22, 42, 913, DateTimeKind.Utc).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 2, 2, 14, 22, 42, 913, DateTimeKind.Utc).AddTicks(6053));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 2, 4, 14, 22, 42, 913, DateTimeKind.Utc).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2025, 2, 5, 14, 22, 42, 913, DateTimeKind.Utc).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2025, 2, 6, 14, 22, 42, 913, DateTimeKind.Utc).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2025, 2, 7, 14, 22, 42, 913, DateTimeKind.Utc).AddTicks(6058));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 14, 22, 42, 913, DateTimeKind.Utc).AddTicks(7297));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 14, 22, 42, 913, DateTimeKind.Utc).AddTicks(7299));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 14, 22, 42, 913, DateTimeKind.Utc).AddTicks(7299));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 14, 22, 42, 913, DateTimeKind.Utc).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 14, 22, 42, 913, DateTimeKind.Utc).AddTicks(7301));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 14, 22, 42, 913, DateTimeKind.Utc).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 14, 22, 42, 913, DateTimeKind.Utc).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 8, 14, 22, 42, 913, DateTimeKind.Utc).AddTicks(7303));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 8, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 8, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(7777));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 8, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(7779));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 8, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 8, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(7781));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 8, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(7782));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 8, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(7783));

            migrationBuilder.UpdateData(
                table: "ForumPosts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 8, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(7784));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8348));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8351));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8353));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8356));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8358));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8361));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8364));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8366));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8369));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8371));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8374));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8376));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8379));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8383));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8386));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8388));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8391));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateCreated",
                value: new DateTime(2025, 2, 8, 16, 22, 42, 913, DateTimeKind.Local).AddTicks(8393));

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 1, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "AchievementDate",
                value: new DateTime(2025, 1, 29, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(2467));

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 4, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "AchievementDate",
                value: new DateTime(2025, 2, 2, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(2469));

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 7, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "AchievementDate",
                value: new DateTime(2025, 2, 6, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(2471));

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 10, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "AchievementDate",
                value: new DateTime(2025, 1, 31, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(2473));
        }
    }
}
