import { ChangeDetectionStrategy, Component, Input, OnChanges, SimpleChanges, OnDestroy } from '@angular/core';
import { ForumService } from '../services/forum.service';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';
import { ForumPostsForFeed } from '../models/forum-posts-for-feed.model';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-forum-posts-for-feed',
  imports: [CommonModule, RouterLink],
  templateUrl: './forum-posts-for-feed.component.html',
  styleUrl: './forum-posts-for-feed.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ForumPostsForFeedComponent implements OnChanges, OnDestroy {
  private _posts$ = new BehaviorSubject<ForumPostsForFeed[]>([]);
  private postsSubscription?: Subscription;
  postsObservable = this._posts$.asObservable();
  id: number = 0;

  @Input() posts$?: Observable<ForumPostsForFeed[]>;

  constructor(private forumService: ForumService, private router: Router, private route: ActivatedRoute) {
    this.id = parseInt(this.route.snapshot.paramMap.get('id') || '');
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['posts$'] && this.posts$) {
      if (this.postsSubscription) {
        this.postsSubscription.unsubscribe(); 
      }
      this.postsSubscription = this.posts$.subscribe(posts => this._posts$.next(posts)); 
    }
  }

  ngOnDestroy(): void {
    if (this.postsSubscription) {
      this.postsSubscription.unsubscribe(); 
    }
  }

  upVote(postId: number): void {
    this.forumService.upvotePost(postId).subscribe(() => this._updatePostVote(postId, 1));
  }

  downVote(postId: number): void {
    this.forumService.downvotePost(postId).subscribe(() => this._updatePostVote(postId, -1));
  }

  private _updatePostVote(postId: number, change: number): void {
    this._posts$.next(
      this._posts$.getValue().map(post => post.id === postId ? {...post, votes: post.votes + change} : post)
    );
  }

  deletePost(postId: number): void {
    this.forumService.deleteForumPost(this.id, postId).subscribe(() => {
      this._posts$.next(this._posts$.getValue().filter(post => post.id !== postId));
    });
  }
}
