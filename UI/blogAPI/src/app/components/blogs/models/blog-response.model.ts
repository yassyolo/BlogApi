export interface BlogResponse {
    title: string;
    slug: string;
    content: any;
    category: string;
    newTags: string[] | null;
    tagIds: number[] | null;
    images: string[];
    toc: {title: string, anchor: string, level: number}[];
}