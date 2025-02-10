using BlogAPI.Models.Domain;

namespace BlogAPI.Constants
{
    public static class AchievementConstants
    {
        // Reading Achievements
        public const string FirstBlogRead = "First Blog Read";
        public const string FirstBlogReadDesc = "Read 1 blog";
        public const int FirstBlogReadPoints = 10;
        public const int FirstBlogConditionValue = 1;

        public const string Bookworm = "Bookworm";
        public const string BookwormDesc = "Read 10 blogs";
        public const int BookwormPoints = 50;
        public const int BookwormConditionValue = 10;

        public const string SuperReader = "Super Reader";
        public const string SuperReaderDesc = "Read 50 blogs";
        public const int SuperReaderPoints = 150;
        public const int SuperReaderConditionValue = 100;

        // Bookmark Achievements
        public const string FirstBookmark = "First Bookmark";
        public const string FirstBookmarkDesc = "Save 1 blog to bookmarks";
        public const int FirstBookmarkPoints = 10;
        public const int FirstBookmarkConditionValue = 1;


        public const string Organizer = "Organizer";
        public const string OrganizerDesc = "Create 3 bookmark folders";
        public const int OrganizerPoints = 30;
        public const int OrganizerConditionValue = 3;

        public const string BookmarkMaster = "Bookmark Master";
        public const string BookmarkMasterDesc = "Save 100 blogs to bookmarks";
        public const int BookmarkMasterPoints = 200;
        public const int BookmarkMasterConditionValue = 100;


        // Blogging Achievements
        public const string FirstBlogPost = "First Blog Post";
        public const string FirstBlogPostDesc = "Publish your first blog";
        public const int FirstBlogPostPoints = 20;
        public const int FirstBlogPostConditionValue = 1;

        public const string ContentCreator = "Content Creator";
        public const string ContentCreatorDesc = "Publish 5 blogs";
        public const int ContentCreatorPoints = 100;
        public const int ContentCreatorConditionValue = 5;

        public const string Influencer = "Influencer";
        public const string InfluencerDesc = "Get 100 likes on your blogs";
        public const int InfluencerPoints = 250;
        public const int InfluencerConditionValue = 100;

        // Commenting Achievements
        public const string FirstComment = "First Comment";
        public const string FirstCommentDesc = "Leave your first comment";
        public const int FirstCommentPoints = 10;
        public const int FirstCommentConditionValue = 1;

        public const string ActiveDiscussant = "Active Discussant";
        public const string ActiveDiscussantDesc = "Leave 10 comments";
        public const int ActiveDiscussantPoints = 50;
        public const int ActiveDiscussantConditionValue = 10;

        public const string CommentMaster = "Comment Master";
        public const string CommentMasterDesc = "Leave 50 comments";
        public const int CommentMasterPoints = 150;
        public const int CommentMasterConditionValue = 50;


    }
}
