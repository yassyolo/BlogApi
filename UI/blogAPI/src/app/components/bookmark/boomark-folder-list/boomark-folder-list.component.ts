import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BookmarkFolderList } from '../models/bookmark-folder-list.model';
import { BookmarkService } from '../services/bookmark.service';
import { CommonModule } from '@angular/common';
import { SearchComponent } from '../../blogs/search/search.component';
import { SortingComponent } from '../sorting/sorting.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-boomark-folder-list',
  imports: [CommonModule, SearchComponent, SortingComponent],
  standalone: true,
  templateUrl: './boomark-folder-list.component.html',
  styleUrl: './boomark-folder-list.component.css'
})
export class BoomarkFolderListComponent implements OnInit {
  bookmarkFolderList$?: Observable<BookmarkFolderList[]>;
  query: string = '';
  sorting: string = '';
  constructor(private bookmarkService: BookmarkService, private router: Router) { }

  ngOnInit(): void {
    this.bookmarkFolderList$ = this.bookmarkService.getAllBookmarkFolders(this.query, this.sorting);
  }

  onSearchQueryChanged(query: string) : void{
    this.query = query;
    this.bookmarkFolderList$ = this.bookmarkService.getAllBookmarkFolders(this.query, this.sorting);
  }
  onSortingChanged(sorting: string) : void{
    this.sorting = sorting;
    this.bookmarkFolderList$ = this.bookmarkService.getAllBookmarkFolders(this.query, this.sorting);
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

  onFolderDelete(folderId: number) : void{
    this.bookmarkService.deleteBookmarkFolder(folderId).subscribe({
      next: () => {
        this.bookmarkFolderList$ = this.bookmarkService.getAllBookmarkFolders(this.query, this.sorting);
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

}
