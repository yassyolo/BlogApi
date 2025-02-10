import { Component, Input } from '@angular/core';
import { BlogDetails } from '../models/blog-details.model';

@Component({
  selector: 'app-author-blog-details',
  imports: [],
  templateUrl: './author-blog-details.component.html',
  styleUrl: './author-blog-details.component.css',
  standalone: true
})
export class AuthorBlogDetailsComponent {
  @Input() blog?: BlogDetails; 
  constructor() { }
  onAuthorClick(authorId: string | undefined): void {
    console.log(`Author ${authorId} clicked`);
  }
}
