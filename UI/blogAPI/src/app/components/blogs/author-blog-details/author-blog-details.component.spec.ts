import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthorBlogDetailsComponent } from './author-blog-details.component';

describe('AuthorBlogDetailsComponent', () => {
  let component: AuthorBlogDetailsComponent;
  let fixture: ComponentFixture<AuthorBlogDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AuthorBlogDetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AuthorBlogDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
