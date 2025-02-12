import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BlogIndex } from '../models/blog-index.model';
import { Observable } from 'rxjs';
import { PagedResponse } from '../models/paged-response.model';
import { BlogRequest } from '../models/blog-request.model';
import { BlogDetails } from '../models/blog-details.model';
import { TopBlogs } from '../models/top-blogs.model';
import { BlogForDelete } from '../models/blog-for-delete.model';

@Injectable({
  providedIn: 'root'
})
export class BlogService {
  private apiUrl = 'https://localhost:5001/BlogPost';

  constructor(private http: HttpClient) { }

  getBlogsIndex(query?: string, pageSize?: number, currentPage?: number, categoryId?: number) : Observable<PagedResponse>{
    let params = new HttpParams();

params = params.set('pageSize', pageSize || 2);
params = params.set('currentPage', currentPage || 1);

if (query) {
  params = params.set('query', query);
}

if (categoryId) {
  params = params.set('categoryId', categoryId);
}

return this.http.get<PagedResponse>(`${this.apiUrl}/all`, { params });
  }

  createBlog(blog: BlogRequest) : Observable<any>{
    const formData = new FormData();
    formData.append('title', blog.title);
    formData.append('slug', blog.slug);
    formData.append('content', blog.content);
    formData.append('categoryId', blog.categoryId.toString());

    for(let i = 0; blog.tagIds && i < blog.tagIds.length; i++){
      formData.append('tagIds', blog.tagIds[i].toString());
    }

    for(let i=0; blog.newTags && i < blog.newTags.length; i++){
      formData.append('newTags', blog.newTags[i]);
    }

    for(let i =0; i < blog.images.length; i++){
      formData.append('images', blog.images[i]);
    }

    formData.append('toc', JSON.stringify(blog.toc));
    console.log(formData.get('toc'));

    return this.http.post(this.apiUrl, formData);

  }

  getBlogBySlug(id: number) : Observable<BlogRequest>{
    return this.http.get<BlogRequest>(`${this.apiUrl}/${id}`);
  }

  updateBlog(blog: BlogRequest) : Observable<any>{
    return this.http.put(`${this.apiUrl}/${blog.slug}`, blog);
  }

  getBlogDetails(id: number) : Observable<BlogDetails>{
    return this.http.get<BlogDetails>(`${this.apiUrl}/${id}`);
  }

  getTopBlogs(authorId?: string): Observable<TopBlogs[]> {
    let params = new HttpParams();
    if (authorId) {
      params = params.set('authorId', authorId);
    }
  
    return this.http.get<TopBlogs[]>(`${this.apiUrl}/top-blogs`, { params });
  }

  getBlogForDelete(id: number) : Observable<BlogForDelete>{ 
    return this.http.get<BlogForDelete>(`${this.apiUrl}/${id}/delete`);
  }

  deleteBlog(id: number) : Observable<any>{
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
