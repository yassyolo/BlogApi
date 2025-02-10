import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryIndex } from '../models/category-index.model';
import { CategoryService } from '../services/category.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ForumService } from '../../forum/services/forum.service';

@Component({
  selector: 'app-category-selector',
  imports: [FormsModule, CommonModule],
  templateUrl: './category-selector.component.html',
  styleUrl: './category-selector.component.css',
  standalone: true
})
export class CategorySelectorComponent implements OnInit {
  @Input() forumCategory?: boolean;
  @Output() categoryChanged = new EventEmitter<string>();
  categorySelected: string = '';
  categories$?: Observable<any>;

  constructor(private categoryService: CategoryService, private forumService: ForumService){}

  onCategoryChange() : void{
    this.categoryChanged.emit(this.categorySelected);
  }

  ngOnInit(): void {
    if(this.forumCategory){
      this.categories$ = this.forumService.getAllcategories();
    }
    else{
      this.categories$ = this.categoryService.getCategories();
    }
  }
}
  

