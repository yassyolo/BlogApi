import { ChangeDetectionStrategy, Component, Input, OnChanges, SimpleChanges, OnDestroy } from '@angular/core';
import { ForumService } from '../services/forum.service';
import { BehaviorSubject, Observable, Subject, Subscription, switchMap, takeUntil } from 'rxjs';
import { ForumPostsForFeed } from '../models/forum-posts-for-feed.model';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router, RouterLink, RouterModule } from '@angular/router';

@Component({
  selector: 'app-forum-posts-for-feed',
  imports: [CommonModule, RouterLink, RouterModule],
  templateUrl: './forum-posts-for-feed.component.html',
  styleUrl: './forum-posts-for-feed.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
  standalone: true
})
export class ForumPostsForFeedComponent implements OnChanges, OnDestroy {
  private _destroy$ = new Subject<void>();
  private _posts$ = new BehaviorSubject<ForumPostsForFeed[]>([]);
  postsObservable = this._posts$.asObservable();

  @Input() posts$?: Observable<ForumPostsForFeed[]>;

  constructor(private forumService: ForumService) {
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['posts$'] && this.posts$) {
      this.posts$.pipe(
        switchMap(posts => { 
          this._posts$.next(posts);
          return new Observable<void>(observer => observer.next()); 
        }),
        takeUntil(this._destroy$) 
      ).subscribe();
    }
  }

  ngOnDestroy(): void {
    this._destroy$.next();
    this._destroy$.complete();
  }

  upVote(postId: number): void {
    this.forumService.downvotePost(postId).pipe(
      switchMap(() => this._updatePostVote(postId, 1))
    ).subscribe();
  }

  downVote(postId: number): void {
    this.forumService.downvotePost(postId)
    .pipe(
      switchMap(() => this._updatePostVote(postId, -1))
    ).subscribe();
  }

  private _updatePostVote(postId: number, change: number): Observable<void> {
    this._posts$.next(
      this._posts$.getValue().map(post => 
        post.id === postId ? { ...post, votes: post.votes + change } : post
      )
    );
    return new Observable<void>(observer => observer.next());
  }

  deletePost(postId: number): void {
    this.forumService.deleteForumPost(postId).pipe(
      switchMap(() => {
        this._posts$.next(this._posts$.getValue().filter(post => post.id !== postId));
        return new Observable<void>(observer => observer.next());
      })
    ).subscribe();
  }
}
