import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForumCategoryFeedComponent } from './forum-category-feed.component';

describe('ForumCategoryFeedComponent', () => {
  let component: ForumCategoryFeedComponent;
  let fixture: ComponentFixture<ForumCategoryFeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ForumCategoryFeedComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ForumCategoryFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
