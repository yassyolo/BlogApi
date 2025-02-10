import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopBlogsComponent } from './top-blogs.component';

describe('TopBlogsComponent', () => {
  let component: TopBlogsComponent;
  let fixture: ComponentFixture<TopBlogsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TopBlogsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TopBlogsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
