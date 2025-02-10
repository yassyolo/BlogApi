import { Component, OnInit } from '@angular/core';
import { BlogTocComponent } from '../blog-toc/blog-toc.component';
import { BlogDetails } from '../models/blog-details.model';
import { BlogService } from '../services/blog.service';
import { ActivatedRoute, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { BookmarkFolderSelectComponent } from '../../bookmark/bookmark-folder-select/bookmark-folder-select.component';
import { TopBlogsComponent } from '../top-blogs/top-blogs.component';
import { AuthorBlogDetailsComponent } from '../author-blog-details/author-blog-details.component';
import { BlogCommentsComponent } from '../blog-comments/blog-comments.component';

@Component({
  selector: 'app-blog-details',
  imports: [BlogTocComponent, BlogCommentsComponent, CommonModule, BookmarkFolderSelectComponent, TopBlogsComponent, AuthorBlogDetailsComponent],
  templateUrl: './blog-details.component.html',
  styleUrl: './blog-details.component.css',
  standalone: true
})
export class BlogDetailsComponent implements OnInit {
 
  blog: BlogDetails = {
        id: 0,
        title: '',
        slug: '',
        content: '',
        category: '',
        tags: [],
        images: [],
        toc: [],
        date: '',
        authorId: '',
        authorName: '',
        authorDescription: '',
        authorImageUri: '',
        comments: [],
        bookmarks: 0,
  }

  selectedBlogId: number | null = null;
  showBookmarkSelect: boolean = false;
  id: number = 0;  
  isLoading: boolean = true;
  errorMessage: string = '';

  constructor(private blogService: BlogService, private route: ActivatedRoute) { 
    this.id = +this.route.snapshot.paramMap.get('id')!;
    }


  ngOnInit(): void {
    if (this.id) {
      this.blogService.getBlogDetails(this.id).subscribe({
        next: (response) => {
          this.blog = response;
          console.log(this.blog);
          this.isLoading = false;
        },
        error: (err) => {
          this.errorMessage = 'Failed to load blog details';
          this.isLoading = false;
        }
      });
    }
  }

  onBookmarkClick(bookId: number): void {
    this.selectedBlogId = bookId;
    this.showBookmarkSelect = true;
  }

  closeBookmarkSelect(): void {
    this.showBookmarkSelect = false;
  }
}
