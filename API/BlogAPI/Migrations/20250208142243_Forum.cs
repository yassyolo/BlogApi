using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogAPI.Migrations
{
    public partial class Forum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Progress",
                table: "UserAchievements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Progress of the achievement");

            migrationBuilder.AddColumn<int>(
                name: "ForumPostId",
                table: "Images",
                type: "int",
                nullable: true,
                comment: "The forum post identifier.");

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Points of user");

            migrationBuilder.CreateTable(
                name: "ForumCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identifier of the forum category")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the forum category")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumCategories", x => x.Id);
                },
                comment: "Categories of the forum");

            migrationBuilder.CreateTable(
                name: "ForumCommunities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for the community")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ForumCategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumCommunities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumCommunities_ForumCategories_ForumCategoryId",
                        column: x => x.ForumCategoryId,
                        principalTable: "ForumCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Communities within a category");

            migrationBuilder.CreateTable(
                name: "ForumPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for the post")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ForumCommunityId = table.Column<int>(type: "int", nullable: false, comment: "Community identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    Votes = table.Column<int>(type: "int", nullable: false, comment: "Votes of the post")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumPosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForumPosts_ForumCommunities_ForumCommunityId",
                        column: x => x.ForumCommunityId,
                        principalTable: "ForumCommunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Posts entity");

            migrationBuilder.CreateTable(
                name: "UserForumCommuntities",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User's unique identifier"),
                    ForumCommunityId = table.Column<int>(type: "int", nullable: false, comment: "Community's unique identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserForumCommuntities", x => new { x.UserId, x.ForumCommunityId });
                    table.ForeignKey(
                        name: "FK_UserForumCommuntities_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserForumCommuntities_ForumCommunities_ForumCommunityId",
                        column: x => x.ForumCommunityId,
                        principalTable: "ForumCommunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "User community entity");

            migrationBuilder.CreateTable(
                name: "ForumPostComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for the comment")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time the comment was created"),
                    ForumPostId = table.Column<int>(type: "int", nullable: false, comment: "Forum post identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    Votes = table.Column<int>(type: "int", nullable: false, comment: "Navigation property to the user that created this comment")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumPostComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumPostComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForumPostComments_ForumPosts_ForumPostId",
                        column: x => x.ForumPostId,
                        principalTable: "ForumPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Comments on a forum post");

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

            migrationBuilder.InsertData(
                table: "ForumCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Technology" },
                    { 2, "Gaming" },
                    { 3, "Education" },
                    { 4, "Entertainment" },
                    { 5, "Science" }
                });

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
                columns: new[] { "AchievementDate", "Progress" },
                values: new object[] { new DateTime(2025, 1, 29, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(2467), 1 });

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 2, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "Progress",
                value: 10);

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 3, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "Progress",
                value: 10);

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 4, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                columns: new[] { "AchievementDate", "Progress" },
                values: new object[] { new DateTime(2025, 2, 2, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(2469), 1 });

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 5, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "Progress",
                value: 3);

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 6, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "Progress",
                value: 3);

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 7, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                columns: new[] { "AchievementDate", "Progress" },
                values: new object[] { new DateTime(2025, 2, 6, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(2471), 1 });

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 8, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "Progress",
                value: 3);

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 9, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                columns: new[] { "AchievementDate", "IsAchieved", "Progress" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3 });

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 10, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                columns: new[] { "AchievementDate", "Progress" },
                values: new object[] { new DateTime(2025, 1, 31, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(2473), 1 });

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 11, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "Progress",
                value: 3);

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 12, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                columns: new[] { "AchievementDate", "IsAchieved", "Progress" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3 });

            migrationBuilder.InsertData(
                table: "ForumCommunities",
                columns: new[] { "Id", "Description", "ForumCategoryId", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, "Discuss coding and development", 1, "Programming", "programming" },
                    { 2, "AI research, projects, and discussions", 1, "AI & Machine Learning", "ai-ml" },
                    { 3, "Discuss PC games and setups", 2, "PC Gaming", "pc-gaming" },
                    { 4, "Talk about console games and news", 2, "Console Gaming", "console-gaming" },
                    { 5, "Best online learning resources", 3, "Online Courses", "online-courses" },
                    { 7, "Latest in movies and television", 4, "Movies & TV Shows", "movies-tv" },
                    { 9, "News about space and planets", 5, "Space & Astronomy", "space-astronomy" }
                });

            migrationBuilder.InsertData(
                table: "ForumPosts",
                columns: new[] { "Id", "Content", "CreatedAt", "ForumCommunityId", "Title", "UserId", "Votes" },
                values: new object[,]
                {
                    { 1, "What do you think are the best programming languages to learn in 2025?", new DateTime(2025, 2, 8, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(7775), 1, "Best Programming Languages in 2025?", "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 15 },
                    { 2, "Looking for tips on improving C# performance and efficiency.", new DateTime(2025, 2, 8, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(7777), 1, "How to optimize C# code?", "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 8 },
                    { 3, "I'm new to Java. Can anyone recommend books or courses?", new DateTime(2025, 2, 8, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(7779), 1, "What are the best resources to learn Java?", "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 5 },
                    { 4, "What do you think will be the major trends in AI this year?", new DateTime(2025, 2, 8, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(7780), 2, "AI trends in 2025?", "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 20 },
                    { 5, "Any recommendations for courses or projects?", new DateTime(2025, 2, 8, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(7781), 2, "Best way to get started with Deep Learning?", "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 12 },
                    { 6, "Should AI have more regulation? What are your views?", new DateTime(2025, 2, 8, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(7782), 2, "Ethics in AI - Your thoughts?", "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 9 },
                    { 7, "Looking for recommendations on budget and high-end gaming builds.", new DateTime(2025, 2, 8, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(7783), 3, "Best PC builds for gaming in 2025?", "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 18 },
                    { 8, "List your favorite PC games of all time and why!", new DateTime(2025, 2, 8, 14, 22, 42, 914, DateTimeKind.Utc).AddTicks(7784), 3, "What are your favorite PC games?", "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 22 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ForumPostId",
                table: "Images",
                column: "ForumPostId",
                unique: true,
                filter: "[ForumPostId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ForumCommunities_ForumCategoryId",
                table: "ForumCommunities",
                column: "ForumCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPostComments_ForumPostId",
                table: "ForumPostComments",
                column: "ForumPostId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPostComments_UserId",
                table: "ForumPostComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_ForumCommunityId",
                table: "ForumPosts",
                column: "ForumCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_UserId",
                table: "ForumPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserForumCommuntities_ForumCommunityId",
                table: "UserForumCommuntities",
                column: "ForumCommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_ForumPosts_ForumPostId",
                table: "Images",
                column: "ForumPostId",
                principalTable: "ForumPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_ForumPosts_ForumPostId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "ForumPostComments");

            migrationBuilder.DropTable(
                name: "UserForumCommuntities");

            migrationBuilder.DropTable(
                name: "ForumPosts");

            migrationBuilder.DropTable(
                name: "ForumCommunities");

            migrationBuilder.DropTable(
                name: "ForumCategories");

            migrationBuilder.DropIndex(
                name: "IX_Images_ForumPostId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Progress",
                table: "UserAchievements");

            migrationBuilder.DropColumn(
                name: "ForumPostId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "AspNetUsers");

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

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9648));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9654));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9656));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9659));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9661));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9663));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9666));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9668));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateCreated",
                value: new DateTime(2025, 2, 7, 19, 8, 21, 519, DateTimeKind.Local).AddTicks(9675));

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 1, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "AchievementDate",
                value: new DateTime(2025, 1, 28, 17, 8, 21, 520, DateTimeKind.Utc).AddTicks(7790));

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 4, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "AchievementDate",
                value: new DateTime(2025, 2, 1, 17, 8, 21, 520, DateTimeKind.Utc).AddTicks(7792));

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 7, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "AchievementDate",
                value: new DateTime(2025, 2, 5, 17, 8, 21, 520, DateTimeKind.Utc).AddTicks(7793));

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 9, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                columns: new[] { "AchievementDate", "IsAchieved" },
                values: new object[] { new DateTime(2025, 1, 28, 17, 8, 21, 520, DateTimeKind.Utc).AddTicks(7794), true });

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 10, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                column: "AchievementDate",
                value: new DateTime(2025, 1, 30, 17, 8, 21, 520, DateTimeKind.Utc).AddTicks(7795));

            migrationBuilder.UpdateData(
                table: "UserAchievements",
                keyColumns: new[] { "AchievementId", "UserId" },
                keyValues: new object[] { 12, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                columns: new[] { "AchievementDate", "IsAchieved" },
                values: new object[] { new DateTime(2025, 2, 3, 17, 8, 21, 520, DateTimeKind.Utc).AddTicks(7796), true });
        }
    }
}
