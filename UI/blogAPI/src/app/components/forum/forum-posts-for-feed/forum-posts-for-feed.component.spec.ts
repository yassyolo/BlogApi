import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForumPostsForFeedComponent } from './forum-posts-for-feed.component';

describe('ForumPostsForFeedComponent', () => {
  let component: ForumPostsForFeedComponent;
  let fixture: ComponentFixture<ForumPostsForFeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ForumPostsForFeedComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ForumPostsForFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
