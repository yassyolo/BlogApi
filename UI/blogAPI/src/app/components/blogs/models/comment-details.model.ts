export interface CommentDetails{
    id: number;
    date: Date;
    authorId: string;
    authorName: string;
    authorImageUri: string;
    content: string;
    likes: number;
}