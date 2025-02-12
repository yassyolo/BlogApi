import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { BehaviorSubject, combineLatest, distinctUntilChanged, map, Observable, switchMap } from 'rxjs';
import { BlogIndex } from '../models/blog-index.model';
import { BlogService } from '../services/blog.service';
import { PagedResponse } from '../models/paged-response.model';
import { PaginationService } from '../services/pagination.service';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-blog-list',
  imports: [CommonModule, RouterLink],
  templateUrl: './blog-list.component.html',
  styleUrl: './blog-list.component.css',
  standalone: true
})
export class BlogListComponent implements OnInit {
  @Input() query: string = '';
  @Input() categoryId: number = 0;
  
  currentPage?: number;
  private _blogs = new BehaviorSubject<BlogIndex[]>([]);
  blogs$: Observable<BlogIndex[]> = this._blogs.asObservable();  

  private _totalPagesSubject = new BehaviorSubject<number | undefined>(undefined);
  totalPages$: Observable<number | undefined> = this._totalPagesSubject.asObservable();

  constructor(private blogService: BlogService, private paginationService: PaginationService) {}

  ngOnInit(): void {
    combineLatest([
      this.paginationService.currentPage$.pipe(distinctUntilChanged()),
      this.paginationService.pageSize$.pipe(distinctUntilChanged()),
      this.getQueryAndCategory() 
    ]).pipe(
      switchMap(([currentPage, pageSize, { query, categoryId }]) => {
        return this.blogService.getBlogsIndex(query, pageSize, currentPage, categoryId);
      })
    ).subscribe({
      next: (response: PagedResponse) => {
        this._blogs.next(response.data);
        this._totalPagesSubject.next(response.totalPages);
      },
      error: (err) => {
        console.error('Error fetching blogs:', err);
      }
    });
  }

  changePage(page: number){
    if (page < 1 || (this._totalPagesSubject.value !== undefined && page > this._totalPagesSubject.value) || page === this.currentPage) return;
    this.paginationService.setCurrentPage(page);
  }

  private getQueryAndCategory(): Observable<{ query: string; categoryId: number }> {
    return combineLatest([this.query$, this.categoryId$]).pipe(
      map(([query, categoryId]) => ({ query, categoryId }))
    );
  }

  private get categoryId$() : Observable<number>{
    return new BehaviorSubject<number>(this.categoryId).asObservable();
  }

  private get query$() : Observable<string>{
    return new BehaviorSubject<string>(this.query).asObservable();
  }

}
