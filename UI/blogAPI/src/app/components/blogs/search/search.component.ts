import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { debounceTime, distinct, distinctUntilChanged, Subject, switchMap, takeUntil } from 'rxjs';

@Component({
  selector: 'app-search',
  imports: [FormsModule],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
  standalone: true
})
export class SearchComponent implements OnDestroy, OnInit {
  ngOnInit(): void {
    this.searchQuerySubject.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      switchMap((query) => {
        console.log('Query emitted:', query); 
        this.searchQueryChanged.emit(query);
        return [];  
      }),
      takeUntil(this.destroy$)
    ).subscribe();
  }
  
 
  @Output() searchQueryChanged = new EventEmitter<string>();
  private searchQuerySubject = new Subject<string>();
  private destroy$ = new Subject<void>();
  query: string = '';

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  onSearch() : void
  {
    this.searchQuerySubject.next(this.query);
  }
}
