import { CommentDetails } from "./comment-details.model";

export interface BlogDetails{
    id: number,
    title: string;
    slug: string;
    content: any;
    category: string;
    tags: string[];
    images: string[];
    toc: {title: string, anchor: string, level: number}[];
    date: string;
    authorId: string;
    authorName: string;
    authorDescription: string;
    authorImageUri: string;
    comments: CommentDetails[];
    bookmarks: number;
}