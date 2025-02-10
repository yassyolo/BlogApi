import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopRankingBlogsComponent } from './top-ranking-blogs.component';

describe('TopRankingBlogsComponent', () => {
  let component: TopRankingBlogsComponent;
  let fixture: ComponentFixture<TopRankingBlogsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TopRankingBlogsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TopRankingBlogsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
