using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogAPI.Migrations
{
    public partial class AddedAchievements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AchievementId",
                table: "Images",
                type: "int",
                nullable: true,
                comment: "The achievement identifier.");

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for the achievement")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the achievement"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Description of the achievement"),
                    ConditionType = table.Column<int>(type: "int", nullable: false, comment: "Condition type of the achievement"),
                    ConditionValue = table.Column<int>(type: "int", nullable: false, comment: "Condition value of the achievement"),
                    Points = table.Column<int>(type: "int", nullable: false, comment: "Points of the achievement")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                },
                comment: "Achievement entity");

            migrationBuilder.CreateTable(
                name: "UserReadBlogs",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    BlogId = table.Column<int>(type: "int", nullable: false, comment: "Blog identifier"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Reading date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReadBlogs", x => new { x.UserId, x.BlogId });
                    table.ForeignKey(
                        name: "FK_UserReadBlogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReadBlogs_BlogPosts_BlogId",
                        column: x => x.BlogId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Reading entity");

            migrationBuilder.CreateTable(
                name: "UserAchievements",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Primary key of the user achievement"),
                    AchievementId = table.Column<int>(type: "int", nullable: false, comment: "Primary key of the achievement"),
                    IsAchieved = table.Column<bool>(type: "bit", nullable: false, comment: "Flag indicating if the achievement is achieved"),
                    AchievementDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time the achievement was achieved")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAchievements", x => new { x.UserId, x.AchievementId });
                    table.ForeignKey(
                        name: "FK_UserAchievements_Achievements_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAchievements_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User achievement entity");

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "Id", "ConditionType", "ConditionValue", "Description", "Name", "Points" },
                values: new object[,]
                {
                    { 1, 1, 1, "Read 1 blog", "First Blog Read", 10 },
                    { 2, 1, 10, "Read 10 blogs", "Bookworm", 50 },
                    { 3, 1, 50, "Read 50 blogs", "Super Reader", 150 },
                    { 4, 2, 1, "Save 1 blog to bookmarks", "First Bookmark", 10 },
                    { 5, 2, 3, "Create 3 bookmark folders", "Organizer", 30 },
                    { 6, 2, 100, "Save 100 blogs to bookmarks", "Bookmark Master", 200 },
                    { 7, 3, 1, "Publish your first blog", "First Blog Post", 20 },
                    { 8, 3, 5, "Publish 5 blogs", "Content Creator", 100 },
                    { 9, 3, 100, "Get 100 likes on your blogs", "Influencer", 250 },
                    { 10, 4, 1, "Leave your first comment", "First Comment", 10 },
                    { 11, 4, 10, "Leave 10 comments", "Active Discussant", 50 },
                    { 12, 4, 50, "Leave 50 comments", "Comment Master", 150 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d30f9a9-6fed-48fb-b3e0-e72f28e7f5f7", "AQAAAAEAACcQAAAAEP5YtIZVPLuo3gFi3N2JJBE5uAKDQnOKfE8Eg5zSA/8B1/6fY6rqpm1cEFKDvx1zGg==", "57a1ca0f-67b3-4ca7-84d0-ab901c54108b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1a5445b-8a5b-4f63-991b-5eeff3cfc85c", "AQAAAAEAACcQAAAAEEnKwI7a4HtnH3OGmn1sz+aai2T7QGaU8CheAFyVn4KJB+eVJKA3kr7axLNQeE+Xgw==", "ca890f5d-e30a-4c11-b4b0-c775d596ca02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2db5e8e0-2b6d-46ec-812e-b8372071be0d", "AQAAAAEAACcQAAAAEOXbZAAuJ78DwHhLEn5aHuX6P8RORkxwsKZrEG7xCMFTbYVSlTSTGRJZEnkVBbfHKA==", "57a4d5c6-7671-4972-bb63-dd7a56d919bb" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 1, 28, 17, 8, 21, 519, DateTimeKind.Utc).AddTicks(5531));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 1, 30, 17, 8, 21, 519, DateTimeKind.Utc).AddTicks(5534));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 2, 1, 17, 8, 21, 519, DateTimeKind.Utc).AddTicks(5536));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 2, 3, 17, 8, 21, 519, DateTimeKind.Utc).AddTicks(5576));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2025, 2, 4, 17, 8, 21, 519, DateTimeKind.Utc).AddTicks(5578));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2025, 2, 5, 17, 8, 21, 519, DateTimeKind.Utc).AddTicks(5579));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2025, 2, 6, 17, 8, 21, 519, DateTimeKind.Utc).AddTicks(5580));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 17, 8, 21, 519, DateTimeKind.Utc).AddTicks(6877));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 17, 8, 21, 519, DateTimeKind.Utc).AddTicks(6878));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 17, 8, 21, 519, DateTimeKind.Utc).AddTicks(6879));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 17, 8, 21, 519, DateTimeKind.Utc).AddTicks(6879));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 17, 8, 21, 519, DateTimeKind.Utc).AddTicks(6880));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 17, 8, 21, 519, DateTimeKind.Utc).AddTicks(6881));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 17, 8, 21, 519, DateTimeKind.Utc).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 7, 17, 8, 21, 519, DateTimeKind.Utc).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9630));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9633));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9636));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9638));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9641));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9643));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9646));

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "AchievementId", "BlogId", "DateCreated", "FileExtension", "FileName", "Title", "Url", "UserId" },
                values: new object[,]
                {
                    { 20, 1, null, new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9648), ".jpg", "1", "1", "https://localhost:7166/Images/Achievements/1.jpg", null },
                    { 21, 2, null, new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9651), ".jpg", "2", "2", "https://localhost:7166/Images/Achievements/2.jpg", null },
                    { 22, 3, null, new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9654), ".jpg", "3", "3", "https://localhost:7166/Images/Achievements/3.jpg", null },
                    { 23, 4, null, new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9656), ".jpg", "4", "4", "https://localhost:7166/Images/Achievements/4.jpg", null },
                    { 24, 5, null, new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9659), ".jpg", "5", "5", "https://localhost:7166/Images/Achievements/5.jpg", null },
                    { 25, 6, null, new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9661), ".jpg", "6", "6", "https://localhost:7166/Images/Achievements/6.jpg", null },
                    { 26, 7, null, new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9663), ".jpg", "7", "7", "https://localhost:7166/Images/Achievements/7.jpg", null },
                    { 27, 8, null, new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9666), ".jpg", "8", "8", "https://localhost:7166/Images/Achievements/8.jpg", null },
                    { 28, 9, null, new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9668), ".jpg", "9", "9", "https://localhost:7166/Images/Achievements/9.jpg", null },
                    { 29, 10, null, new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9671), ".jpg", "10", "10", "https://localhost:7166/Images/Achievements/10.jpg", null },
                    { 30, 11, null, new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9673), ".jpg", "11", "11", "https://localhost:7166/Images/Achievements/11.jpg", null },
                    { 31, 12, null, new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9675), ".jpg", "12", "12", "https://localhost:7166/Images/Achievements/12.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "AchievementId", "UserId", "AchievementDate", "IsAchieved" },
                values: new object[,]
                {
                    { 1, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", new DateTime(2025, 1, 28, 17, 8, 21, 520, DateTimeKind.Utc).AddTicks(7790), true },
                    { 2, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 3, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 4, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", new DateTime(2025, 2, 1, 17, 8, 21, 520, DateTimeKind.Utc).AddTicks(7792), true },
                    { 5, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 6, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 7, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", new DateTime(2025, 2, 5, 17, 8, 21, 520, DateTimeKind.Utc).AddTicks(7793), true },
                    { 8, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 9, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", new DateTime(2025, 1, 28, 17, 8, 21, 520, DateTimeKind.Utc).AddTicks(7794), true },
                    { 10, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", new DateTime(2025, 1, 30, 17, 8, 21, 520, DateTimeKind.Utc).AddTicks(7795), true },
                    { 11, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 12, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", new DateTime(2025, 2, 3, 17, 8, 21, 520, DateTimeKind.Utc).AddTicks(7796), true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_AchievementId",
                table: "Images",
                column: "AchievementId",
                unique: true,
                filter: "[AchievementId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievements_AchievementId",
                table: "UserAchievements",
                column: "AchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReadBlogs_BlogId",
                table: "UserReadBlogs",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Achievements_AchievementId",
                table: "Images",
                column: "AchievementId",
                principalTable: "Achievements",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Achievements_AchievementId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "UserAchievements");

            migrationBuilder.DropTable(
                name: "UserReadBlogs");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropIndex(
                name: "IX_Images_AchievementId",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DropColumn(
                name: "AchievementId",
                table: "Images");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "031a2e4f-d0e0-48da-b1d2-3fda1f1277f4", "AQAAAAEAACcQAAAAEGeavXI+lWKrRsDOKsyaN1oPzHSjsVwg9wqVyGoHAzaUyI0hkQvqCTkQ6fmQ/TYc8Q==", "10768241-252d-447b-9612-4e1b7d7374f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb219d5c-1347-4532-b872-ec5a3c234e96", "AQAAAAEAACcQAAAAENzU9IQPF4JPvPIzG57v+kVoYZVI2CGsVmAEyvfTdO1vMMNmy2RHV+DJpZqSQWo+gw==", "de0ba297-f580-49b7-b7d3-e97846c767af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95cc219f-6fe6-49c7-8c32-4a9e9f5be025", "AQAAAAEAACcQAAAAEJ9BLTLEd35qeX+7Rlvvlvtd3t4muXrqoGkqOAeXXVEu8IKYcYpK7YwbHrYB4ipgYw==", "7a211c72-1212-4a30-b1ad-bb6e3501d3ea" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 1, 24, 17, 41, 34, 114, DateTimeKind.Utc).AddTicks(9369));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 1, 26, 17, 41, 34, 114, DateTimeKind.Utc).AddTicks(9372));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 1, 28, 17, 41, 34, 114, DateTimeKind.Utc).AddTicks(9374));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 1, 30, 17, 41, 34, 114, DateTimeKind.Utc).AddTicks(9375));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2025, 1, 31, 17, 41, 34, 114, DateTimeKind.Utc).AddTicks(9377));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2025, 2, 1, 17, 41, 34, 114, DateTimeKind.Utc).AddTicks(9378));

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2025, 2, 2, 17, 41, 34, 114, DateTimeKind.Utc).AddTicks(9379));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 3, 17, 41, 34, 115, DateTimeKind.Utc).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 3, 17, 41, 34, 115, DateTimeKind.Utc).AddTicks(413));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 3, 17, 41, 34, 115, DateTimeKind.Utc).AddTicks(414));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 3, 17, 41, 34, 115, DateTimeKind.Utc).AddTicks(414));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 3, 17, 41, 34, 115, DateTimeKind.Utc).AddTicks(415));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 3, 17, 41, 34, 115, DateTimeKind.Utc).AddTicks(415));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 3, 17, 41, 34, 115, DateTimeKind.Utc).AddTicks(416));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 2, 3, 17, 41, 34, 115, DateTimeKind.Utc).AddTicks(417));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 2, 3, 19, 41, 34, 115, DateTimeKind.Local).AddTicks(1205));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2025, 2, 3, 19, 41, 34, 115, DateTimeKind.Local).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2025, 2, 3, 19, 41, 34, 115, DateTimeKind.Local).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2025, 2, 3, 19, 41, 34, 115, DateTimeKind.Local).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2025, 2, 3, 19, 41, 34, 115, DateTimeKind.Local).AddTicks(1216));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2025, 2, 3, 19, 41, 34, 115, DateTimeKind.Local).AddTicks(1218));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateCreated",
                value: new DateTime(2025, 2, 3, 19, 41, 34, 115, DateTimeKind.Local).AddTicks(1221));
        }
    }
}
