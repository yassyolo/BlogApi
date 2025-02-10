import { Component, EventEmitter, Output } from '@angular/core';
import { PaginationService } from '../services/pagination.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-search',
  imports: [FormsModule],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
  standalone: true
})
export class SearchComponent {
  @Output() searchQueryChanged = new EventEmitter<string>();
  query: string = '';

  onSearch() : void
  {
    console.log(this.query);
      this.searchQueryChanged.emit(this.query);
  }
}
