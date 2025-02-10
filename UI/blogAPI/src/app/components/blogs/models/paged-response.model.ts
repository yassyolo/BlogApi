import { BlogIndex } from "./blog-index.model";

export interface PagedResponse{
    data: BlogIndex[],
    pageSize: number,
    currentPage: number,
    totalPages: number
}