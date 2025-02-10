import { Component, Input, OnInit } from '@angular/core';
import { BlogService } from '../services/blog.service';
import { Observable } from 'rxjs';
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
  @Input() authorId: string | undefined;
  topBlogs$?: Observable<TopBlogs[]>;

  constructor(private blogService: BlogService) {}

  ngOnInit(): void {
    this.topBlogs$ = this.blogService.getTopBlogs(this.authorId);
  }

}
