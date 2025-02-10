import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PaginationService {
    private currentPageSource = new BehaviorSubject<number>(1); 
    currentPage$ = this.currentPageSource.asObservable(); 

    private pageSizeSource = new BehaviorSubject<number>(2);
    pageSize$ = this.pageSizeSource.asObservable();
  constructor() { }

  setCurrentPage(currentPage: number){ 
    if (this.currentPageSource.value !== currentPage) { 
      this.currentPageSource.next(currentPage);  
    }
  }

  setPageSize(pageSize: number){
    this.pageSizeSource.next(pageSize);
  }
}
