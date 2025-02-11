export interface ForumComment {
    id: number;
    content: string;
    createdAt: string;
    authorId: string;
    authorName: string;
    authorImageUrl: string;
    votes: number;
}
    