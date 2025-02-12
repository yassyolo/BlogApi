import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { BlogService } from '../services/blog.service';
import { BehaviorSubject, catchError, Observable, of, switchMap } from 'rxjs';
import { TopBlogs } from '../models/top-blogs.model';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-top-blogs',
  imports: [CommonModule, RouterLink],
  standalone: true,
  templateUrl: './top-blogs.component.html',
  styleUrl: './top-blogs.component.css'
})
export class TopBlogsComponent implements OnInit {
  private authorIdSubject = new BehaviorSubject<string | undefined>(undefined);
  @Input() set authorId(value: string | undefined) {
    this.authorIdSubject.next(value);
  }
  
  topBlogs$?: Observable<TopBlogs[]>;

  constructor(private blogService: BlogService) {}

  ngOnInit(): void {
    this.topBlogs$ = this.authorIdSubject.pipe(
      switchMap((authorId) => {
        if (!authorId) {
          return this.blogService.getTopBlogs().pipe(
            catchError((error) => {
              console.error('Error fetching top blogs (no authorId):', error);
              return of([]); 
            })
          );
        }
        return this.blogService.getTopBlogs(authorId).pipe(
          catchError((error) => {
            console.error(`Error fetching top blogs for author ${authorId}:`, error);
            return of([]); 
          })
        );
      }))
  }
}  