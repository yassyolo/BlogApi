import { Component, Input, OnInit } from '@angular/core';
import { BehaviorSubject, catchError, distinct, distinctUntilChanged, Observable, switchMap } from 'rxjs';
import { MostPopularCommunities } from '../models/most-popular-communities.model';
import { ForumService } from '../services/forum.service';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-communities-with-category-id',
  imports: [CommonModule],
  templateUrl: './communities-with-category-id.component.html',
  styleUrl: './communities-with-category-id.component.css'
})
export class CommunitiesWithCategoryIdComponent implements OnInit{
  private categoryIdSubject = new BehaviorSubject<number>(0);
  @Input() set categoryId(value : number){
    this.categoryIdSubject.next(value);
  }

  communities$?: Observable<MostPopularCommunities[]>;

  constructor(private forumService: ForumService, private router: Router) { }

  ngOnInit(): void {
    this.communities$ = this.categoryIdSubject.pipe(
      distinctUntilChanged(),
      switchMap(categoryId => this.forumService.getForumCommunitiesByCategory(categoryId).pipe(
        catchError((error) => {
          console.error(`Error fetching communities for category ${categoryId}:`, error);
          return [];
        })
      ))
    );
  }
  
  onCommunityClick(forumId: number): void {
    this.router.navigate([`/forum/community/${forumId}`]);
  }

}
