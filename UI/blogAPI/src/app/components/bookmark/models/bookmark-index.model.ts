export interface BookmarkIndex{
    id: number,
    name : string,
    creationDate: string,
    blogId: number | null,
    blogTitle: string | null,
    blogImageUrl: string | null,
    blogContent: string | null,
    authorId: string | null,    
    authorName: string | null,
    authorUsername: string | null,
    authorCommentsCount: number | null,
    authorBookmarksCount: number | null,
    authorDescription: string | null,
    authorImageUrl: string | null
}