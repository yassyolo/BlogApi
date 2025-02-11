import { Component, Input, OnInit } from '@angular/core';
import { LastVisitedCommunitiesComponent } from '../last-visited-communities/last-visited-communities.component';
import { CategorySelectorComponent } from '../../blogs/category-selector/category-selector.component';
import { CommonModule } from '@angular/common';
import { ForumService } from '../services/forum.service';
import { BehaviorSubject, filter, Observable, switchMap, tap } from 'rxjs';
import { ForumPostDetails } from '../models/forum-post-details.model';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { CommunityDetailsComponent } from '../community-details/community-details.component';
import { ForumCommunity } from '../models/forum-community.model';
import { FormsModule } from '@angular/forms';
import { ForumComment } from '../models/forum-comment.model';

@Component({
  selector: 'app-forum-post-details',
  imports: [LastVisitedCommunitiesComponent, CategorySelectorComponent, CommonModule, CommunityDetailsComponent, FormsModule],
  templateUrl: './forum-post-details.component.html',
  styleUrl: './forum-post-details.component.css'
})
export class ForumPostDetailsComponent implements OnInit {
  @Input() communityDetails$?: Observable<ForumCommunity>;

  _post = new BehaviorSubject<ForumPostDetails | null>(null);
  _comments = new BehaviorSubject<ForumComment[] | null>([]);

  forumPost$?= this._post.asObservable().pipe(filter((post): post is ForumPostDetails  => post != null));
  comments$ = this._comments.asObservable();

  postId: number = 0;
  newComment: string = '';
  constructor(private forumService: ForumService, private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    this.route.paramMap.pipe(
      switchMap(params => {
        this.postId = parseInt(params.get('id') || '');
        return this.forumService.getForumPostDetails(this.postId);
      }),
      tap(post => {
        this._post.next(post);
        this._comments.next(post.comments);
      })
    ).subscribe();

    this.communityDetails$ = this.route.paramMap.pipe(
      switchMap(params => this.forumService.getForumCommunity(parseInt(params.get('id') || '')))
    );
  }

  onCategoryChange(categoryId: number): void {
    this.router.navigate([`/forum/category/${categoryId}`]);
  }

  upVote(postId: number): void {
    this.forumService.upvotePost(postId).subscribe(() => this._updateVotes(1));
  }
  
  downVote(postId: number): void {
    this.forumService.downvotePost(postId).subscribe(() => this._updateVotes(1));
  }
  
  deletePost(postId: number): void {
    this.forumService.deleteForumPost(postId).subscribe(() => {
      this.router.navigate(['/forum']);
    });
  }

  likeComment(commentId: number): void {
    this.forumService.upVoteComment(this.postId, commentId).subscribe(() => this._changeCommentVotes(commentId, 1));
  }

  unLinkeComment(commentId: number): void {
    this.forumService.downVoteComment(this.postId, commentId).subscribe(() => this._changeCommentVotes(commentId, -1));
  }

  private _changeCommentVotes(commentId: number, change: number): void {
    const comments = this._comments.getValue();
    if (comments) {
      this._comments.next(
        comments.map(comment =>
          comment.id === commentId ? { ...comment, votes: comment.votes + change } : comment
        )
      );
    }
  }

  
  submitComment(event: Event): void {
    event.preventDefault();
    if (this.newComment.trim()) {
      this.forumService.createForumComment(this.postId, this.newComment).subscribe((comment) => {
        const currentComments = this._comments.getValue() || [];
        this._comments.next([...currentComments, comment]);
        this.newComment = '';
      });
    }
  }
  private _updateVotes(change: number): void {
    var post = this._post.getValue();
    if(post){
      this._post.next({...post, votes: post.votes + change});
    }
  }
  
}
