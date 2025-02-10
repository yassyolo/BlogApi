import { Component, OnInit, Output } from '@angular/core';
import { LastVisitedCommunitiesComponent } from '../last-visited-communities/last-visited-communities.component';
import { CategorySelectorComponent } from '../../blogs/category-selector/category-selector.component';
import { CommonModule } from '@angular/common';
import { ForumService } from '../services/forum.service';
import { Observable } from 'rxjs';
import { ForumPostsForFeed } from '../models/forum-posts-for-feed.model';
import { ActivatedRoute } from '@angular/router';
import { SortingComponent } from '../../bookmark/sorting/sorting.component';
import { ForumPostsForFeedComponent } from '../forum-posts-for-feed/forum-posts-for-feed.component';
import { ForumCategory } from '../models/forum-category.model';

@Component({
  selector: 'app-forum-category-feed',
  imports: [LastVisitedCommunitiesComponent, CategorySelectorComponent, CommonModule, ForumPostsForFeedComponent],
  templateUrl: './forum-category-feed.component.html',
  styleUrl: './forum-category-feed.component.css'
})
export class ForumCategoryFeedComponent implements OnInit{
  @Output() posts$?: Observable<ForumPostsForFeed[]>;
  showPosts: boolean = true;
  categoryDetails$?: Observable<ForumCategory>;
  forumCategory: boolean = true;
  id: number = 0;

  constructor(private forumService: ForumService, private route: ActivatedRoute){
    this.id = parseInt(this.route.snapshot.paramMap.get('id') || '');
  }

  onPostsClick() : void{
    this.showPosts = true;
  }

  onCommunitiesClick() : void{
    this.showPosts = false;
  }

  ngOnInit(): void {
    this.posts$ = this.forumService.getFeed(null, null, this.id);
  }

  onCategoryChange(categoryId: number) : void{
    this.forumService.getForumCommunitiesAndPostsByCategory(categoryId);
  }

}
