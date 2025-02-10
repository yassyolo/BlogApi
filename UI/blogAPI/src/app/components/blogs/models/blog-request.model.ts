export interface BlogRequest {
    title: string;
    slug: string;
    content: any;
    categoryId: number;
    newTags: string[] | null;
    tagIds: number[] | null;
    images: File[];
    toc: {title: string, anchor: string, level: number}[];
}