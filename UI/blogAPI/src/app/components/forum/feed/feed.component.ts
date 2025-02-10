import { Component, OnInit } from '@angular/core';
import { CategorySelectorComponent } from '../../blogs/category-selector/category-selector.component';
import { MostPopularCommunitiesComponent } from '../most-popular-communities/most-popular-communities.component';
import { LastVisitedCommunitiesComponent } from '../last-visited-communities/last-visited-communities.component';
import { CommunitiesForFeedComponent } from '../communities-for-feed/communities-for-feed.component';
import { ForumPostsForFeedComponent } from '../forum-posts-for-feed/forum-posts-for-feed.component';
import { SortingComponent } from '../../bookmark/sorting/sorting.component';
import { ForumService } from '../services/forum.service';
import { Observable } from 'rxjs';
import { ForumPostsForFeed } from '../models/forum-posts-for-feed.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-feed',
  imports: [CategorySelectorComponent, MostPopularCommunitiesComponent, LastVisitedCommunitiesComponent, CommunitiesForFeedComponent, ForumPostsForFeedComponent, SortingComponent],
  standalone: true,
  templateUrl: './feed.component.html',
  styleUrl: './feed.component.css'
})
export class FeedComponent implements OnInit{
  posts$?: Observable<ForumPostsForFeed[]>;
  forumCategory: boolean = true;
  sorting: string = '';

  constructor(private forumService: ForumService, private router: Router) {}

  ngOnInit(): void {
    this.posts$ = this.forumService.getFeed(this.sorting);
  }

  onCategoryChange(categoryId: number) : void{
    this.forumService.getForumCommunitiesAndPostsByCategory(categoryId);
  }

  onSortingChanged(sorting: string) : void{
    this.sorting = sorting;
    this.posts$ = this.forumService.getFeed(this.sorting);
  }
}
