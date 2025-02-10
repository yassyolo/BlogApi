import { Component, OnInit } from '@angular/core';
import { PaginationService } from '../../blogs/services/pagination.service';
import { SearchComponent } from "../../blogs/search/search.component";
import { BlogListComponent } from '../../blogs/blog-list/blog-list.component';
import { CategorySelectorComponent } from "../../blogs/category-selector/category-selector.component";
import { CommonModule } from '@angular/common';
import { TopBlogsComponent } from "../../blogs/top-blogs/top-blogs.component";

@Component({
  selector: 'app-home',
  imports: [SearchComponent, BlogListComponent, CategorySelectorComponent, CommonModule, TopBlogsComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  standalone: true
})
export class HomeComponent implements OnInit {
query: string = '';
categoryId: number = 0;
forumCategory: boolean = false;

constructor(private paginationService: PaginationService) { }

ngOnInit(): void {
  this.paginationService.setCurrentPage(1);
}

onSearchQueryChange(query: string) : void{
  this.query = query;
}

onCategoryChange(categoryId: number) : void{
  this.categoryId = categoryId;
  this.paginationService.setCurrentPage(1);
}

}
