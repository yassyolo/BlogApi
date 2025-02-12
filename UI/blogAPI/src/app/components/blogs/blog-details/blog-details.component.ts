import { Component, OnInit } from '@angular/core';
import { BlogTocComponent } from '../blog-toc/blog-toc.component';
import { BlogDetails } from '../models/blog-details.model';
import { BlogService } from '../services/blog.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { BookmarkFolderSelectComponent } from '../../bookmark/bookmark-folder-select/bookmark-folder-select.component';
import { TopBlogsComponent } from '../top-blogs/top-blogs.component';
import { AuthorBlogDetailsComponent } from '../author-blog-details/author-blog-details.component';
import { BlogCommentsComponent } from '../blog-comments/blog-comments.component';
import { catchError, Observable, of, switchMap, tap } from 'rxjs';
import { DeleteBlogComponent } from '../delete-blog/delete-blog.component';

@Component({
  selector: 'app-blog-details',
  imports: [BlogTocComponent, BlogCommentsComponent,DeleteBlogComponent, CommonModule, BookmarkFolderSelectComponent, TopBlogsComponent, AuthorBlogDetailsComponent],
  templateUrl: './blog-details.component.html',
  styleUrl: './blog-details.component.css',
  standalone: true
})
export class BlogDetailsComponent implements OnInit {
 blog$?: Observable<BlogDetails>;

  selectedBlogId: number | null = null;
  showDeleteContainer: boolean = false;
  showBookmarkSelect: boolean = false;
  id: number = 0;  
  errorMessage: string = '';

  constructor(private blogService: BlogService,
     private route: ActivatedRoute, 
     private router: Router) 
    {}


    ngOnInit(): void {
      this.blog$ = this.route.paramMap.pipe(
        switchMap(params => {
          const id = Number(params.get('id'));
          if (!id) {
            this.errorMessage = 'Invalid blog ID';
            return of();
          }
          return this.blogService.getBlogDetails(id).pipe(
            tap(blog => console.log('Blog details:', blog)),
            catchError(error => {
              this.errorMessage = 'Failed to load blog details';
              return of(); 
            })
          );
        })
      );
      
    }

  onBookmarkClick(bookId: number): void {
    this.selectedBlogId = bookId;
    this.showBookmarkSelect = true;
  }

  closeBookmarkSelect(): void {
    this.showBookmarkSelect = false;
  }

  onShowDeleteContainerClick(blogId: number): void{
    this.showDeleteContainer = true;    
  }

  onEditClick(blogId: number): void{
    this.router.navigate(['/edit', blogId]);
  }

  onHideDeleteContainerClick() : void{
    this.showDeleteContainer = false;

  }
}


