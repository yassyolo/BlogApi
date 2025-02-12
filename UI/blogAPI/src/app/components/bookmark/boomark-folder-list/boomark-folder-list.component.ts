import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, catchError, combineLatest, Observable, switchMap } from 'rxjs';
import { BookmarkFolderList } from '../models/bookmark-folder-list.model';
import { BookmarkService } from '../services/bookmark.service';
import { CommonModule } from '@angular/common';
import { SearchComponent } from '../../blogs/search/search.component';
import { SortingComponent } from '../sorting/sorting.component';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-boomark-folder-list',
  imports: [CommonModule, SearchComponent, SortingComponent, RouterLink],
  standalone: true,
  templateUrl: './boomark-folder-list.component.html',
  styleUrl: './boomark-folder-list.component.css'
})
export class BoomarkFolderListComponent implements OnInit {
  bookmarkForDelete$?: Observable<BookmarkFolderList>;
  showDeleteContainer: boolean = false;
  bookmarkFolderList$?: Observable<BookmarkFolderList[]>;
  querySubject = new BehaviorSubject<string>('');
  sortingSubject = new BehaviorSubject<string>('');
  constructor(private bookmarkService: BookmarkService, private router: Router) { }

  ngOnInit(): void {
    this.bookmarkFolderList$ = combineLatest([this.querySubject, this.sortingSubject]).pipe(
      switchMap(([query, sorting]) => {
        return this.bookmarkService.getAllBookmarkFolders(query, sorting).pipe(
          catchError((error) => {
            console.error('Error fetching bookmark folders:', error);
            return []; 
          })
        );
      })
    );
  }

  onSearchQueryChanged(query: string) : void{
    this.querySubject.next(query);
  }
  onSortingChanged(sorting: string) : void{
    this.sortingSubject.next(sorting);
  }

  onFolderSelect(folderId: number) : void{
    this.bookmarkService.getBookmarksByFolderId(folderId).subscribe({
      next: (response) => {
        this.router.navigate(['/bookmarks', folderId]);
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  onShowDeleteClick(folderId: number) : void{
    this.bookmarkForDelete$ = this.bookmarkService.getBookmarkFolderForDelete(folderId);

    this.showDeleteContainer = true;
  }

  OnDeleteFolder(folderId: number) : void{
    this.bookmarkService.deleteBookmarkFolder(folderId).subscribe({
      next: () => {
        this.bookmarkFolderList$ = this.bookmarkService.getAllBookmarkFolders(this.querySubject.value, this.sortingSubject.value);
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  cancelDeletion() : void{
    this.showDeleteContainer = false;
  }

}
