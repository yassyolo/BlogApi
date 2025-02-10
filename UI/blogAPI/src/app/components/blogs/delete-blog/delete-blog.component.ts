import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BlogService } from '../services/blog.service';
import { CommonModule, Location } from '@angular/common';


@Component({
  selector: 'app-delete-blog',
  imports: [CommonModule],
  standalone: true,
  templateUrl: './delete-blog.component.html',
  styleUrl: './delete-blog.component.css'
})
export class DeleteBlogComponent {
  slug: string = '';
  errorMessage: string = '';
constructor(private router: Router, private route: ActivatedRoute, private blogService: BlogService, private location: Location) {
  this.slug = this.route.snapshot.paramMap.get('slug') || '';
 }

deleteBlog() : void
{
  this.blogService.deleteBlog(this.slug).subscribe({
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
  this.location.back();
}
}
