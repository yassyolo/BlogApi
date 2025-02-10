import { Component, Input, OnInit } from '@angular/core';
import { CommentDetails } from '../models/comment-details.model';
import { Observable, switchMap, tap } from 'rxjs';
import { CommentsService } from '../services/comments.service';
import { ActivatedRoute } from '@angular/router';
import { CommentRequest } from '../models/comment-request.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-blog-comments',
  imports: [CommonModule, FormsModule],
  standalone: true,
  templateUrl: './blog-comments.component.html',
  styleUrl: './blog-comments.component.css'
})
export class BlogCommentsComponent  {
  @Input() comments: CommentDetails[] = [];
  newComment: string = '';
  id: number = 0;

  constructor(private commentsService: CommentsService, private route: ActivatedRoute) { 
    this.id = parseInt(this.route.snapshot.paramMap.get('id') || '');
   }


   submitComment(event: Event): void {
    event.preventDefault();  // ✅ Prevent page reload
    if (this.newComment.trim()) {  // Ensure it's not empty
      this.commentsService.postComment(this.id, this.newComment).pipe(
        switchMap(() => this.commentsService.getCommentsByBlogId(this.id)),
        tap(() => this.newComment = '') // ✅ Reset input field after successful submit
      ).subscribe({
        next: (comments: CommentDetails[]) => {
          this.comments = comments;
        },
        error: (error) => {
          console.error('Error posting comment:', error);
        }
      });
    }
  }
  

likeComment(commentId: number){
  this.commentsService.likeComment(this.id, commentId).pipe(
    switchMap(() => this.commentsService.getCommentsByBlogId(this.id))
  ).subscribe({
    next: (comments) => {
      this.comments = comments;
    },
    error: (error) => {
      console.error('Error liking comment:', error);
    }
  })
}

}
