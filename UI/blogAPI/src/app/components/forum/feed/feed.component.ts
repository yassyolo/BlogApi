import { Component, CUSTOM_ELEMENTS_SCHEMA, Inject, OnInit } from '@angular/core';
import { CategorySelectorComponent } from '../../blogs/category-selector/category-selector.component';
import { MostPopularCommunitiesComponent } from '../most-popular-communities/most-popular-communities.component';
import { LastVisitedCommunitiesComponent } from '../last-visited-communities/last-visited-communities.component';
import { CommunitiesForFeedComponent } from '../communities-for-feed/communities-for-feed.component';
import { ForumPostsForFeedComponent } from '../forum-posts-for-feed/forum-posts-for-feed.component';
import { SortingComponent } from '../../bookmark/sorting/sorting.component';
import { ForumService } from '../services/forum.service';
import { BehaviorSubject, Observable, switchMap } from 'rxjs';
import { ForumPostsForFeed } from '../models/forum-posts-for-feed.model';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-feed',
  imports: [CategorySelectorComponent, RouterModule, MostPopularCommunitiesComponent, LastVisitedCommunitiesComponent, CommunitiesForFeedComponent, ForumPostsForFeedComponent, SortingComponent],
  standalone: true,
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.css']})
export class FeedComponent implements OnInit{
  posts$?: Observable<ForumPostsForFeed[]>;
  private sorting$= new BehaviorSubject<string | null>(null);

  constructor(private forumService: ForumService, private router: Router) {}

  ngOnInit(): void {
    this.posts$ = this.sorting$.pipe(switchMap(sorting => this.forumService.getFeed(sorting))); 
  }

  onCategoryChange(categoryId: number) : void{
    this.router.navigate([`/forum/category/${categoryId}`]);
  }

  onSortingChanged(sorting: string) : void{
    this.sorting$.next(sorting);
  }
}
