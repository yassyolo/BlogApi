import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { CommentDetails } from '../models/comment-details.model';
import { BehaviorSubject, Observable, pipe, switchMap, tap } from 'rxjs';
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
export class BlogCommentsComponent implements OnInit, OnChanges {
  @Input() comments: CommentDetails[] = [];
  _comments = new BehaviorSubject<CommentDetails[]>([]);
  comments$ = this._comments.asObservable();
  newComment: string = '';
  id: number = 0;

  constructor(private commentsService: CommentsService, private route: ActivatedRoute) { 
   }
  ngOnChanges(changes: SimpleChanges): void {
    if(changes['comments'] && changes['comments'].currentValue) {
      this._comments.next([...changes['comments'].currentValue]);
      console.log('Comments:', this._comments.getValue());
    }
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = parseInt(params['id']);
    });
  }


  submitComment(event: Event): void {
    event.preventDefault();
    if (this.newComment.trim()) {
      this.commentsService.postComment(this.id, this.newComment).subscribe(comment => {
        this._comments.next([...this._comments.getValue(), comment]);
        console.log('New comment added:', this._comments.getValue());
        this.newComment = ''; 
      });
    }
  }
  

  likeComment(commentId: number): void {
    this.commentsService.likeComment(this.id, commentId).subscribe(() => {
      this._comments.next(
        this._comments.getValue().map(comment =>
          comment.id === commentId ? { ...comment, likes: comment.likes + 1 } : comment
        )
      );
    });
  }

}
