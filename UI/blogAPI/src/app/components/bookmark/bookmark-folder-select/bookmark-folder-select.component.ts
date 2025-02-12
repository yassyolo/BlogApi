import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BookmarkService } from '../services/bookmark.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { BookmarkListSelect } from '../models/bookmark-list-select.model';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { AddToExistingFolder } from '../models/add-to-existing-folder.model';
import { CreateNewFolder } from '../models/add-new-folder.model';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-bookmark-folder-select',
  imports: [CommonModule, FormsModule],
  templateUrl: './bookmark-folder-select.component.html',
  styleUrl: './bookmark-folder-select.component.css'
})
export class BookmarkFolderSelectComponent implements OnInit {
  private blogIdSubject = new BehaviorSubject<number | null>(null);
  @Input() set blogId (value: number | null){
    this.blogIdSubject.next(value);
  }

  private authorIdSubject = new BehaviorSubject<string | null>(null);
  @Input() set authorId(value: string | null){
    this.authorIdSubject.next(value);
  }

  @Output() close = new EventEmitter<void>();

  bookmarksList$?: Observable<BookmarkListSelect[]>;

  isCreatingNewFolder: boolean = false;
  newFolderName: string = '';

  constructor(private bookmarkService: BookmarkService) {
   }

  ngOnInit(): void {
    this.bookmarksList$ = this.bookmarkService.getAllBookMarksForAdding();
  }

  onFolderSelect(folderId: number): void {
    const addToExistingFolderRequest: AddToExistingFolder = {
      blogId: this.blogIdSubject.getValue(),
      authorId: this.authorIdSubject.getValue(),
      folderId: folderId
    };
      this.bookmarkService.addToExistingFolder(addToExistingFolderRequest).subscribe({
      next: () => {
        this.close.emit();
      },
      error: (err) => {
        console.log('Error adding to folder:', err);
      }
    })
  }
  onNewFolderClick(): void {
    this.isCreatingNewFolder = true;
  }

  onCreateFolderClick(): void {
    if (this.newFolderName) {
      const createNewFolderRequest: CreateNewFolder = {
        name: this.newFolderName,
        blogId: this.blogIdSubject.getValue(),
        authorId: this.authorIdSubject.getValue()
      };
      
      this.bookmarkService.createNewFolder(createNewFolderRequest).subscribe({
        next: () => {
          this.close.emit();
        },
        error: (err) => {
          console.log('Error creating new folder:', err);
        }
      });
    }
  }
  closeFolderSelect() : void{
    this.close.emit();
  }

}
