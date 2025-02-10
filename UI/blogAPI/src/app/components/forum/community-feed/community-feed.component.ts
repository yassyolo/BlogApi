import { Component, OnInit, Output } from '@angular/core';
import { ForumPostsForFeedComponent } from '../forum-posts-for-feed/forum-posts-for-feed.component';
import { LastVisitedCommunitiesComponent } from '../last-visited-communities/last-visited-communities.component';
import { CommonModule } from '@angular/common';
import { CategorySelectorComponent } from '../../blogs/category-selector/category-selector.component';
import { SortingComponent } from '../../bookmark/sorting/sorting.component';
import { ForumService } from '../services/forum.service';
import { Observable } from 'rxjs';
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
  forumCategory: boolean = true;
  sorting: string = '';
  posts$?: Observable<ForumPostsForFeed[]>;
  forumId?: number;

  constructor(private forumService: ForumService, private route: ActivatedRoute, private router: Router) {}
  ngOnInit(): void {
    this.forumId = parseInt(this.route.snapshot.paramMap.get('id') || '');
    this.communityDetails$ = this.forumService.getForumCommunity(this.forumId);
    this.posts$ = this.forumService.getFeed(this.sorting, this.forumId);
  }

  onSortingChanged(sorting: string) : void{
    this.sorting = sorting;
    this.posts$ = this.forumService.getFeed(this.sorting);
  }

  onCategoryChange(categoryId: number) : void{
    this.forumService.getForumCommunitiesAndPostsByCategory(categoryId);
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
