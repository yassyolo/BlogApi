import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookmarkFolderContentsComponent } from './bookmark-folder-contents.component';

describe('BookmarkFolderContentsComponent', () => {
  let component: BookmarkFolderContentsComponent;
  let fixture: ComponentFixture<BookmarkFolderContentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BookmarkFolderContentsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookmarkFolderContentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
