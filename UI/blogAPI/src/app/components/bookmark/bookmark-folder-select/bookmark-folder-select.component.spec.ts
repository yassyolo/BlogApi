import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookmarkFolderSelectComponent } from './bookmark-folder-select.component';

describe('BookmarkFolderSelectComponent', () => {
  let component: BookmarkFolderSelectComponent;
  let fixture: ComponentFixture<BookmarkFolderSelectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BookmarkFolderSelectComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookmarkFolderSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
