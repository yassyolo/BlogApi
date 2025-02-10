import { ForumPostsForFeed } from "./forum-posts-for-feed.model";

export interface ForumCommunity {
    id: number;
    name: string;
    description: string;
    imageUri: string;
    category: string;
    categoryId: number;
    members: number;
    postsCount: number;
    creationDate: string;
    rules: string[];
    rank: number;
}
 