import { Component, OnDestroy, OnInit, Output } from '@angular/core';
import { LastVisitedCommunitiesComponent } from '../last-visited-communities/last-visited-communities.component';
import { CategorySelectorComponent } from '../../blogs/category-selector/category-selector.component';
import { CommonModule } from '@angular/common';
import { ForumService } from '../services/forum.service';
import { BehaviorSubject, distinct, distinctUntilChanged, Observable, Subject, switchMap, takeUntil } from 'rxjs';
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
export class ForumCategoryFeedComponent implements OnInit, OnDestroy{
  @Output() posts$?: Observable<ForumPostsForFeed[]>;
  _destroy$ = new Subject<void>();
  showPosts: boolean = true;
  categoryDetails$?: Observable<ForumCategory>;

  private categoryIdSubject = new BehaviorSubject<number>(0);
  categoryId$? = this.categoryIdSubject.asObservable();

  constructor(private forumService: ForumService, private route: ActivatedRoute, private router: Router){
  }
  ngOnDestroy(): void {
    this._destroy$.next();
    this._destroy$.complete();
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
        const categoryId = parseInt(params.get('id') || '', 10);
        this.categoryIdSubject.next(categoryId);
        return this.forumService.getFeed(null, null, categoryId);
      }),
      takeUntil(this._destroy$)
    );

    this.categoryDetails$ = this.categoryIdSubject.pipe(
      distinctUntilChanged(), 
      switchMap(categoryId => categoryId ? this.forumService.getForumCategoryDetails(categoryId) : new Observable<ForumCategory>()),
      takeUntil(this._destroy$) 
    );
  }


  onCategoryChange(categoryId: number) : void{
      this.router.navigate([`/forum/category/${categoryId}`]);
  }

}
