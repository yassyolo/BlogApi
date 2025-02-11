using BlogAPI.Models.Configurations;
using BlogAPI.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stream = BlogAPI.Models.Domain.Stream;

namespace BlogAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var adminRoleId = "e83adcc5-9da0-4021-a816-3cb518656890";
            var userRoleId = "b2dd1368-11e6-4084-ad72-dd78c95c3290";

            var roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper(),
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole()
                {
                    Id = userRoleId,
                    Name = "User",
                    NormalizedName = "User".ToUpper(),
                    ConcurrencyStamp = userRoleId
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);

            var adminId = "f3b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            var admin = new ApplicationUser()
            {
                Id = adminId,
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin@blog.com",
                NormalizedUserName = "admin@blog.com".ToUpper(),
                Email = "admin@blog.com",
                NormalizedEmail = "admin@blog.com".ToUpper(),
            };
            admin.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(admin, "Admin123!");


            var userId = "67b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3b";
            var user = new ApplicationUser()
            {
                Id = userId,
                FirstName = "User",
                LastName = "User",
                UserName = "user1",
                NormalizedUserName = "user1".ToUpper(),
                Email = "user@blog.com",
                NormalizedEmail = "user@blog.com".ToUpper()
            };
            user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, "User123!");

            var user2Id = "79b3b3b3-3b3b-3b3b-3b3b-3b3b3b3b3b3c";
            var user2 = new ApplicationUser()
            {
                Id = user2Id,
                UserName = "user2",
                FirstName = "User2",
                LastName = "User2",
                NormalizedUserName = "user2".ToUpper(),
                Email = "user2@blog.com",
                NormalizedEmail = "user2@blog.com".ToUpper()
            };
            user2.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user2, "User123!");

            modelBuilder.Entity<ApplicationUser>().HasData(user);
            modelBuilder.Entity<ApplicationUser>().HasData(admin);
            modelBuilder.Entity<ApplicationUser>().HasData(user2);

            var adminUserRoles = new IdentityUserRole<string>()
            {
                RoleId = adminRoleId,
                UserId = adminId
            };
            var userUserRoles = new IdentityUserRole<string>()
            {
                RoleId = userRoleId,
                UserId = userId
            };
            var user2UserRoles = new IdentityUserRole<string>()
            {
                RoleId = userRoleId,
                UserId = user2Id
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(adminUserRoles);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userUserRoles);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(user2UserRoles);
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new AchievementConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new BlogPostTagCofiguration());
            modelBuilder.ApplyConfiguration(new BookmarkConfiguration());
            modelBuilder.ApplyConfiguration(new BookmarkFolderConfiguration());
            modelBuilder.ApplyConfiguration(new UserAchievementConfiguration());
            modelBuilder.ApplyConfiguration(new UserReadBlogConfiguration());
            modelBuilder.ApplyConfiguration(new ForumCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ForumCommunityConfiguration());
            modelBuilder.ApplyConfiguration(new UserForumCommunityConfiguration());
            modelBuilder.ApplyConfiguration(new ForumPostConfiguration());
            modelBuilder.ApplyConfiguration(new ForumPostCommentConfiguration());
            modelBuilder.ApplyConfiguration(new VisitedForumCommunityConfiguration());
            modelBuilder.ApplyConfiguration(new StreamConfiguration());
            modelBuilder.ApplyConfiguration(new UserStreamConfiguration());
        }

        public DbSet<Blog> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPostTag> BlogPostsTags { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<BookmarkFolder> BookmarkFolders { get; set; }
        public DbSet<UserReadBlog> UserReadBlogs { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }
        public DbSet<ForumCategory> ForumCategories { get; set; }
        public DbSet<ForumCommunity> ForumCommunities { get; set; }
        public DbSet<UserForumCommuntity> UserForumCommuntities { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<ForumPostComment> ForumPostComments { get; set; }
        public DbSet<VisitedForumCommunity> VisitedForumCommunities { get; set; }
        public DbSet<Stream> Streams { get; set; }
        public DbSet<UserStream> UserStreams { get; set; }
    }
}
