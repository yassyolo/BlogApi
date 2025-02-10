import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BlogTocComponent } from './blog-toc.component';

describe('BlogTocComponent', () => {
  let component: BlogTocComponent;
  let fixture: ComponentFixture<BlogTocComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BlogTocComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BlogTocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
