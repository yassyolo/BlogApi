using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "First name of the user"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Last name of the user"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Description of the user"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                },
                comment: "Application user entity");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for the category")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the category"),
                    Slug = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "URL handle for the category")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Category entity");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The unique identifier of the tag.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The name of the tag."),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The URL handle for the tag.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                },
                comment: "This class represents a tag for a blog post.");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookmarkFolders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The unique identifier of the bookmark folder.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The name of the bookmark folder."),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The user identifier."),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date the bookmark folder was created.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookmarkFolders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookmarkFolders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "This class represents a bookmark folder.");

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for the blog post")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Title of the blog post"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Content of the blog post"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time the blog post was created"),
                    Slug = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Slug of the blog post"),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Author identifier"),
                    ViewCount = table.Column<int>(type: "int", nullable: false, comment: "Number of views the blog post has"),
                    BookmarkCount = table.Column<int>(type: "int", nullable: false, comment: "Number of bookmarks the blog post has"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier"),
                    TocJson = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Table of contents for the blog post")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPosts_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlogPosts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Blog post entity");

            migrationBuilder.CreateTable(
                name: "BlogPostsTags",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false, comment: "Primary key of the blog post tag"),
                    TagId = table.Column<int>(type: "int", nullable: false, comment: "Primary key of the tag")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostsTags", x => new { x.BlogId, x.TagId });
                    table.ForeignKey(
                        name: "FK_BlogPostsTags_BlogPosts_BlogId",
                        column: x => x.BlogId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPostsTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Tags of the blog post");

            migrationBuilder.CreateTable(
                name: "Bookmarks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for the bookmark")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: true, comment: "Blog identifier"),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "Author identifier (ApplicationUser ID)"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time the bookmark was created"),
                    FolderId = table.Column<int>(type: "int", nullable: false, comment: "Folder identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookmarks_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookmarks_BlogPosts_BlogId",
                        column: x => x.BlogId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookmarks_BookmarkFolders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "BookmarkFolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Bookmark entity");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier for the comment")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Content of the comment"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time the comment was created"),
                    BlogPostId = table.Column<int>(type: "int", nullable: false, comment: "Blog post identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    Likes = table.Column<int>(type: "int", nullable: false, comment: "Number of likes the comment has")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_BlogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Comment entity");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The unique identifier of the blog image.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The name of the file."),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The file extension of the image."),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The title of the image."),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "The URL of the image."),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date the image was created."),
                    BlogId = table.Column<int>(type: "int", nullable: true, comment: "The blog post identifier."),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "The user identifier.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_BlogPosts_BlogId",
                        column: x => x.BlogId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "This class represents a blog image.");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b2dd1368-11e6-4084-ad72-dd78c95c3290", "b2dd1368-11e6-4084-ad72-dd78c95c3290", "User", "USER" },
                    { "e83adcc5-9da0-4021-a816-3cb518656890", "e83adcc5-9da0-4021-a816-3cb518656890", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Description", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 0, "031a2e4f-d0e0-48da-b1d2-3fda1f1277f4", "", "user@blog.com", false, "User", "User", false, null, "USER@BLOG.COM", "USER1", "AQAAAAEAACcQAAAAEGeavXI+lWKrRsDOKsyaN1oPzHSjsVwg9wqVyGoHAzaUyI0hkQvqCTkQ6fmQ/TYc8Q==", null, false, "10768241-252d-447b-9612-4e1b7d7374f5", false, "user1" },
                    { "79b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c", 0, "eb219d5c-1347-4532-b872-ec5a3c234e96", "", "user2@blog.com", false, "User2", "User2", false, null, "USER2@BLOG.COM", "USER2", "AQAAAAEAACcQAAAAENzU9IQPF4JPvPIzG57v+kVoYZVI2CGsVmAEyvfTdO1vMMNmy2RHV+DJpZqSQWo+gw==", null, false, "de0ba297-f580-49b7-b7d3-e97846c767af", false, "user2" },
                    { "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 0, "95cc219f-6fe6-49c7-8c32-4a9e9f5be025", "", "admin@blog.com", false, "Admin", "Admin", false, null, "ADMIN@BLOG.COM", "ADMIN@BLOG.COM", "AQAAAAEAACcQAAAAEJ9BLTLEd35qeX+7Rlvvlvtd3t4muXrqoGkqOAeXXVEu8IKYcYpK7YwbHrYB4ipgYw==", null, false, "7a211c72-1212-4a30-b1ad-bb6e3501d3ea", false, "admin@blog.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, "Technology", "technology" },
                    { 2, "Programming", "programming" },
                    { 3, "Artificial Intelligence", "ai" },
                    { 4, "Cloud Computing", "cloud-computing" },
                    { 5, "Cybersecurity", "cybersecurity" },
                    { 6, "Health & Wellness", "health-wellness" },
                    { 7, "Finance", "finance" },
                    { 8, "Education", "education" },
                    { 9, "Business", "business" },
                    { 10, "Gaming", "gaming" },
                    { 11, "Sports", "sports" },
                    { 12, "Entertainment", "entertainment" },
                    { 13, "Science", "science" },
                    { 14, "Travel", "travel" },
                    { 15, "Food & Cooking", "food-cooking" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, "Web Development", "web-development" },
                    { 2, "Machine Learning", "machine-learning" },
                    { 3, "AI", "ai" },
                    { 4, "Data Science", "data-science" },
                    { 5, "Cloud Computing", "cloud-computing" },
                    { 6, "Cybersecurity", "cybersecurity" },
                    { 7, "Blockchain", "blockchain" },
                    { 8, "Software Engineering", "software-engineering" },
                    { 9, "Technology", "technology" },
                    { 10, "Cooking", "cooking" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b2dd1368-11e6-4084-ad72-dd78c95c3290", "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                    { "b2dd1368-11e6-4084-ad72-dd78c95c3290", "79b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c" },
                    { "e83adcc5-9da0-4021-a816-3cb518656890", "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" }
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "AuthorId", "BookmarkCount", "CategoryId", "Content", "CreationDate", "Slug", "Title", "TocJson", "ViewCount" },
                values: new object[,]
                {
                    { 1, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 35, 2, "Web development is an exciting field that involves building modern websites...", new DateTime(2025, 1, 24, 17, 41, 34, 114, DateTimeKind.Utc).AddTicks(9369), "getting-started-with-web-development", "Getting Started with Web Development", "[]", 250 },
                    { 2, "79b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c", 50, 3, "Machine learning is revolutionizing the tech industry...", new DateTime(2025, 1, 26, 17, 41, 34, 114, DateTimeKind.Utc).AddTicks(9372), "machine-learning-for-beginners", "Machine Learning for Beginners", "[]", 420 },
                    { 3, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 60, 9, "Blockchain is transforming industries beyond just cryptocurrencies...", new DateTime(2025, 1, 28, 17, 41, 34, 114, DateTimeKind.Utc).AddTicks(9374), "the-rise-of-blockchain-technology", "The Rise of Blockchain Technology", "[]", 380 },
                    { 4, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 80, 5, "As cyber threats evolve, staying ahead with the best security practices is crucial...", new DateTime(2025, 1, 30, 17, 41, 34, 114, DateTimeKind.Utc).AddTicks(9375), "cybersecurity-best-practices-2025", "Cybersecurity Best Practices for 2025", "[]", 600 },
                    { 5, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 70, 4, "Cloud computing has changed the way businesses operate...", new DateTime(2025, 1, 31, 17, 41, 34, 114, DateTimeKind.Utc).AddTicks(9377), "future-of-cloud-computing", "The Future of Cloud Computing", "[]", 510 },
                    { 6, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 95, 3, "Artificial Intelligence is no longer a concept of the future...", new DateTime(2025, 2, 1, 17, 41, 34, 114, DateTimeKind.Utc).AddTicks(9378), "how-ai-is-shaping-the-future", "How AI is Shaping the Future", "[]", 720 },
                    { 7, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b", 40, 6, "Understanding nutrition is key to maintaining a healthy lifestyle...", new DateTime(2025, 2, 2, 17, 41, 34, 114, DateTimeKind.Utc).AddTicks(9379), "science-behind-healthy-eating", "The Science Behind Healthy Eating", "[]", 350 }
                });

            migrationBuilder.InsertData(
                table: "BlogPostsTags",
                columns: new[] { "BlogId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 8 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 7 },
                    { 3, 9 },
                    { 4, 6 },
                    { 4, 9 },
                    { 5, 5 },
                    { 5, 9 },
                    { 6, 3 },
                    { 6, 4 },
                    { 7, 6 },
                    { 7, 10 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BlogPostId", "Content", "CreatedDate", "Likes", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Great insights! Thanks for sharing.", new DateTime(2025, 2, 3, 17, 41, 34, 115, DateTimeKind.Utc).AddTicks(412), 5, "79b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c" },
                    { 2, 1, "I found this very useful. Keep it up!", new DateTime(2025, 2, 3, 17, 41, 34, 115, DateTimeKind.Utc).AddTicks(413), 3, "79b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c" },
                    { 3, 1, "Interesting perspective, but I have a different view.", new DateTime(2025, 2, 3, 17, 41, 34, 115, DateTimeKind.Utc).AddTicks(414), 2, "79b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c" },
                    { 4, 1, "Can you elaborate more on this topic?", new DateTime(2025, 2, 3, 17, 41, 34, 115, DateTimeKind.Utc).AddTicks(414), 4, "79b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c" },
                    { 5, 1, "This is exactly what I was looking for!", new DateTime(2025, 2, 3, 17, 41, 34, 115, DateTimeKind.Utc).AddTicks(415), 6, "79b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c" },
                    { 6, 2, "Nice explanation! Helped me a lot.", new DateTime(2025, 2, 3, 17, 41, 34, 115, DateTimeKind.Utc).AddTicks(415), 2, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                    { 7, 2, "I think there's a small mistake in the second section.", new DateTime(2025, 2, 3, 17, 41, 34, 115, DateTimeKind.Utc).AddTicks(416), 1, "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b" },
                    { 8, 3, "Awesome article! Thanks for posting.", new DateTime(2025, 2, 3, 17, 41, 34, 115, DateTimeKind.Utc).AddTicks(417), 3, "79b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "BlogId", "DateCreated", "FileExtension", "FileName", "Title", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 2, 3, 19, 41, 34, 115, DateTimeKind.Local).AddTicks(1205), ".png", "test", "test", "https://localhost:7166/Images/test.png", null },
                    { 2, 2, new DateTime(2025, 2, 3, 19, 41, 34, 115, DateTimeKind.Local).AddTicks(1208), ".png", "test", "test", "https://localhost:7166/Images/test.png", null },
                    { 3, 3, new DateTime(2025, 2, 3, 19, 41, 34, 115, DateTimeKind.Local).AddTicks(1211), ".png", "test", "test", "https://localhost:7166/Images/test.png", null },
                    { 4, 4, new DateTime(2025, 2, 3, 19, 41, 34, 115, DateTimeKind.Local).AddTicks(1213), ".png", "test", "test", "https://localhost:7166/Images/test.png", null },
                    { 5, 5, new DateTime(2025, 2, 3, 19, 41, 34, 115, DateTimeKind.Local).AddTicks(1216), ".png", "test", "test", "https://localhost:7166/Images/test.png", null },
                    { 6, 6, new DateTime(2025, 2, 3, 19, 41, 34, 115, DateTimeKind.Local).AddTicks(1218), ".png", "test", "test", "https://localhost:7166/Images/test.png", null },
                    { 7, 7, new DateTime(2025, 2, 3, 19, 41, 34, 115, DateTimeKind.Local).AddTicks(1221), ".png", "test", "test", "https://localhost:7166/Images/test.png", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_AuthorId",
                table: "BlogPosts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_CategoryId",
                table: "BlogPosts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostsTags_TagId",
                table: "BlogPostsTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_BookmarkFolders_UserId",
                table: "BookmarkFolders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_AuthorId",
                table: "Bookmarks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_BlogId",
                table: "Bookmarks",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_FolderId",
                table: "Bookmarks",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogPostId",
                table: "Comments",
                column: "BlogPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_BlogId",
                table: "Images",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BlogPostsTags");

            migrationBuilder.DropTable(
                name: "Bookmarks");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "BookmarkFolders");

            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
