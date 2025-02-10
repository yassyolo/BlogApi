import { Component, OnInit } from '@angular/core';
import { SearchComponent } from '../../blogs/search/search.component';
import { CommonModule } from '@angular/common';
import { SortingComponent } from '../sorting/sorting.component';
import { BookmarkIndex } from '../models/bookmark-index.model';
import { Observable } from 'rxjs';
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
  query: string = '';
  sorting: string = '';
  folderName?: string;
  creationDate?: string;

  constructor(private bookmarkService: BookmarkService,
    private route: ActivatedRoute, private router: Router)
  {
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.folderId = +(params.get('id')!) || 0;
      console.log(this.folderId);
      this.bookmarks$ = this.bookmarkService.getBookmarksByFolderId(this.folderId, this.query, this.sorting );
      this.bookmarks$.subscribe((bookmarks: BookmarkIndex[]) => {
        this.folderName = bookmarks[0]?.name;
        this.creationDate = bookmarks[0]?.creationDate;
      });
    })
  }
  onSearchQueryChanged(query: string): void {
    this.query = query;
    this.bookmarks$ = this.bookmarkService.getBookmarksByFolderId(this.folderId, this.query, this.sorting);
  }

  onSortingChanged(sortBy: string): void {
    this.sorting = sortBy;
    this.bookmarks$ = this.bookmarkService.getBookmarksByFolderId(this.folderId, this.query, this.sorting);
  }

  onBlogClick(blogId: number): void {
    this.router.navigate(['/blogs', blogId]);
  }

  onAuthorClick(authorId: string): void {
    this.router.navigate(['/authors', authorId]);
  }
}
