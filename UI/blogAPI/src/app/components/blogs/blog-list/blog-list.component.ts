import { Component, Input, OnInit } from '@angular/core';
import { distinctUntilChanged, Observable } from 'rxjs';
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
  blogs$?: BlogIndex[];
  pageSize?: number;
  currentPage?: number;
  totalPages?: number;

  constructor(private blogService: BlogService, private paginationService: PaginationService) {}


  ngOnInit(): void {
    this.paginationService.currentPage$
    .pipe(distinctUntilChanged())
    .subscribe(page => {
      this.currentPage = page;
      this.loadBlogs();
    });

  this.paginationService.pageSize$
    .pipe(distinctUntilChanged())
    .subscribe(size => {
      this.pageSize = size;
      this.loadBlogs();
    });

  }

  loadBlogs(): void{
    this.blogService.getBlogsIndex(this.query, this.pageSize, this.currentPage, this.categoryId)
    .subscribe((response) => {
      this.blogs$ = response.data;
      this.totalPages = response.totalPages;
    });  
  }

  changePage(page: number){
    if (page < 1 || (this.totalPages !== undefined && page > this.totalPages) || page === this.currentPage) return;
    this.paginationService.setCurrentPage(page);
  }

}
