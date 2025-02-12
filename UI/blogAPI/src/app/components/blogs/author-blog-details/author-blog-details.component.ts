import { Component, Input } from '@angular/core';
import { BlogDetails } from '../models/blog-details.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-author-blog-details',
  imports: [CommonModule],
  templateUrl: './author-blog-details.component.html',
  styleUrl: './author-blog-details.component.css',
  standalone: true
})
export class AuthorBlogDetailsComponent {
  @Input() ownerDetails?: {ownerId: string, ownerName: string, ownerImageUri: string, ownerDescription: string}; 
  constructor() { }
  onAuthorClick(authorId: string | undefined): void {
  }
}
