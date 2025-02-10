export interface TopRankingBlog{
    id: number,
    title: string,
    date: string,
    imageUri: string,
    categoryId: number,
    categoryName: string,
    authorId: string,
    authorName: string,
    commentsCount: number,
    readingsCount: number,
    bookmarksCount: number
}