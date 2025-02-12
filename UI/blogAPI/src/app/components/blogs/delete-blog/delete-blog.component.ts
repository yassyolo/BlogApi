import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BlogService } from '../services/blog.service';
import { CommonModule, Location } from '@angular/common';
import { catchError, Observable, of, switchMap } from 'rxjs';
import { BlogForDelete } from '../models/blog-for-delete.model';


@Component({
  selector: 'app-delete-blog',
  imports: [CommonModule],
  standalone: true,
  templateUrl: './delete-blog.component.html',
  styleUrl: './delete-blog.component.css'
})
export class DeleteBlogComponent implements OnInit{
  @Output() close= new EventEmitter<void>();
  blogForDelete$?: Observable<BlogForDelete>;
  id: number = 0;
  errorMessage: string = '';

  constructor(private router: Router,
     private route: ActivatedRoute, 
     private blogService: BlogService) {
 }
  ngOnInit(): void {
    this.blogForDelete$ = this.route.paramMap.pipe(
      switchMap(params => {
        const id = Number(params.get('id'));
        if (!id) {
          this.errorMessage = 'Invalid blog ID';
          return of();
        }
        return this.blogService.getBlogForDelete(id).pipe(
          catchError(error => {
            this.errorMessage = 'Failed to load blog details';
            return of(); 
          })
        );
      })
    );
  }

deleteBlog() : void
{
  this.blogService.deleteBlog(this.id).subscribe({
    next: () => {
      this.router.navigate(['/blogs']);
    },
    error: (error) => {
      console.error('Error deleting blog:', error);
      this.errorMessage = 'Failed to delete blog. Please try again later.';
    }
});
}

cancelDeletion() : void{
  this.close.emit();
}
}
