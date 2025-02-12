import { Component, OnInit } from '@angular/core';
import { SearchComponent } from '../../blogs/search/search.component';
import { CommonModule } from '@angular/common';
import { SortingComponent } from '../sorting/sorting.component';
import { BookmarkIndex } from '../models/bookmark-index.model';
import { BehaviorSubject, catchError, combineLatest, debounceTime, Observable, switchMap } from 'rxjs';
import { BookmarkService } from '../services/bookmark.service';
import { ActivatedRoute, Router } from '@angular/router';
import { TruncateStringPipe } from '../truncate-string.pipe';

@Component({
  selector: 'app-bookmark-folder-contents',
  imports: [SearchComponent, CommonModule, SortingComponent, TruncateStringPipe],
  templateUrl: './bookmark-folder-contents.component.html',
  styleUrl: './bookmark-folder-contents.component.css',
  standalone: true
})
export class BookmarkFolderContentsComponent implements OnInit {
  folderId?: number;
  bookmarks$?: Observable<BookmarkIndex[]>;
  folderName?: string;
  creationDate?: string;
  query: string = '';
  sorting: string = '';

  private querySubject = new BehaviorSubject<string>('');
  private sortingSubject = new BehaviorSubject<string>('');

  constructor(private bookmarkService: BookmarkService,
    private route: ActivatedRoute, private router: Router)
  {
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.folderId = Number(params.get('id'));
      this.loadBookmarks();
    });

    combineLatest([this.querySubject.pipe(debounceTime(300)), this.sortingSubject]).pipe(
      switchMap(([query, sorting]) => {
        return this.bookmarkService.getBookmarksByFolderId(this.folderId!, query, sorting);
      }),
      catchError((error) => {
        console.error('Error fetching bookmarks:', error);
        return [];
      }
    )).subscribe(bookmarks => {
      console.log('Bookmarks:', bookmarks);
      this.creationDate = bookmarks[0].creationDate;
      this.folderName = bookmarks[0].name;
    })
  }

  private loadBookmarks(): void {
    if (this.folderId) {
      this.bookmarks$ = this.bookmarkService.getBookmarksByFolderId(this.folderId, this.query, this.sorting);
  
      this.bookmarks$.subscribe(response => {
        if (response && response.length > 0) {
          this.folderName = response[0].name;
          this.creationDate = response[0].creationDate;
        }
      });
    }
  }
  onSearchQueryChanged(query: string): void {
    this.query = query;
    this.querySubject.next(query);
  }

  onSortingChanged(sortBy: string): void {
    this.sorting = sortBy;
    this.sortingSubject.next(sortBy);
  }

  onBlogClick(blogId: number): void {
    this.router.navigate(['/blogs', blogId]);
  }

  onAuthorClick(authorId: string): void {
    this.router.navigate(['/authors', authorId]);
  }
}
