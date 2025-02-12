import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CommentDetails } from '../models/comment-details.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {

  private apiUrl = 'https://localhost:5001/blogs';
  constructor(private hhtp: HttpClient) { }

  getCommentsByBlogId(id: number) : Observable<CommentDetails[]>{ 
    return this.hhtp.get<CommentDetails[]>(`${this.apiUrl}/${id}/comments`);
  }

  postComment(blogId: number, comment: string): Observable<CommentDetails> {
   return this.hhtp.post<CommentDetails>(`${this.apiUrl}/${blogId}/comments`, JSON.stringify(comment), {
      headers: { 'Content-Type': 'application/json' }
    });
  }
  
  
  likeComment(id: number, commentId: number) : Observable<any>{
    return this.hhtp.put(`${this.apiUrl}/${id}/comments/${commentId}/like`, {});
  }
}
