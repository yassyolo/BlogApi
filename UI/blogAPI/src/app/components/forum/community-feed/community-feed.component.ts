import { Component, OnInit, Output } from '@angular/core';
import { ForumPostsForFeedComponent } from '../forum-posts-for-feed/forum-posts-for-feed.component';
import { LastVisitedCommunitiesComponent } from '../last-visited-communities/last-visited-communities.component';
import { CommonModule } from '@angular/common';
import { CategorySelectorComponent } from '../../blogs/category-selector/category-selector.component';
import { SortingComponent } from '../../bookmark/sorting/sorting.component';
import { ForumService } from '../services/forum.service';
import { BehaviorSubject, Observable, switchMap } from 'rxjs';
import { ForumPostsForFeed } from '../models/forum-posts-for-feed.model';
import { ActivatedRoute, Router } from '@angular/router';
import { ForumCommunity } from '../models/forum-community.model';
import { CommunityDetailsComponent } from '../community-details/community-details.component';

@Component({
  selector: 'app-community-feed',
  imports: [ForumPostsForFeedComponent, CommunityDetailsComponent, LastVisitedCommunitiesComponent, CommonModule, CategorySelectorComponent, SortingComponent],
  templateUrl: './community-feed.component.html',
  styleUrl: './community-feed.component.css'
})
export class CommunityFeedComponent implements OnInit{
  @Output() communityDetails$?: Observable<ForumCommunity>;
  private sorting$ = new BehaviorSubject<string | null>(null);
  posts$?: Observable<ForumPostsForFeed[]>;
  forumCommunityId?: number;

  constructor(private forumService: ForumService, private route: ActivatedRoute, private router: Router) {}
  ngOnInit(): void {
    this.posts$ = this.route.paramMap.pipe(
      switchMap(params => {
        const forumId = parseInt(params.get('id') || '', 10);
        this.forumCommunityId = forumId;
        this.communityDetails$ = this.forumService.getForumCommunity(forumId);
  
        return this.sorting$.pipe(
          switchMap(sorting => this.forumService.getFeed(sorting, forumId, null))
        );
      })
    );
  }
  
  onSortingChanged(sorting: string) : void{
    this.sorting$.next(sorting);
  }

  onCategoryChange(categoryId: number) : void{
    this.router.navigate([`/forum/category/${categoryId}`]);
  }

  joinCommunity(forumId: number) : void{
    this.forumService.joinCommunity(forumId);
  }

  leaveCommunity(forumId: number) : void{
    this.forumService.leaveCommunity(forumId);
  }

  createPost(forumId: number) : void{
    this.router.navigate(['forum', forumId, 'create-post']);
  }
}
