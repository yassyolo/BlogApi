import { Component, OnInit, Output } from '@angular/core';
import { LastVisitedCommunitiesComponent } from '../last-visited-communities/last-visited-communities.component';
import { CategorySelectorComponent } from '../../blogs/category-selector/category-selector.component';
import { CommonModule } from '@angular/common';
import { ForumService } from '../services/forum.service';
import { Observable, switchMap } from 'rxjs';
import { ForumPostsForFeed } from '../models/forum-posts-for-feed.model';
import { ActivatedRoute } from '@angular/router';
import { SortingComponent } from '../../bookmark/sorting/sorting.component';
import { ForumPostsForFeedComponent } from '../forum-posts-for-feed/forum-posts-for-feed.component';
import { ForumCategory } from '../models/forum-category.model';
import { Router } from '@angular/router';
import { CommunitiesWithCategoryIdComponent } from '../communities-with-category-id/communities-with-category-id.component';

@Component({
  selector: 'app-forum-category-feed',
  imports: [CommunitiesWithCategoryIdComponent, LastVisitedCommunitiesComponent, CategorySelectorComponent, CommonModule, ForumPostsForFeedComponent],
  templateUrl: './forum-category-feed.component.html',
  styleUrl: './forum-category-feed.component.css'
})
export class ForumCategoryFeedComponent implements OnInit{
  @Output() posts$?: Observable<ForumPostsForFeed[]>;
  showPosts: boolean = true;
  categoryDetails$?: Observable<ForumCategory>;
  categoryId?: number;

  constructor(private forumService: ForumService, private route: ActivatedRoute, private router: Router){
  }

  onPostsClick() : void{
    this.showPosts = true;
  }

  onCommunitiesClick() : void{
    this.showPosts = false;
  }

  ngOnInit(): void {
    this.posts$ = this.route.paramMap.pipe(
      switchMap(params => {
        this.categoryId = parseInt(params.get('id') || '');
        this.categoryDetails$ = this.forumService.getForumCategoryDetails(this.categoryId);

        return this.forumService.getFeed(null, null, this.categoryId);
      }))
  }

  onCategoryChange(categoryId: number) : void{
      this.router.navigate([`/forum/category/${categoryId}`]);
  }

}
