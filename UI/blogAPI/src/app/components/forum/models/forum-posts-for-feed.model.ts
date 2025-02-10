export interface ForumPostsForFeed {
    id: number;
    title: string;
    content: string;
    date: string;
    imageUri: string;
    commentsCount: number;
    votes: number;
    communityName: string;
    communityImageUri: string;
    authorName: string;
    authorImageUri: string;
}