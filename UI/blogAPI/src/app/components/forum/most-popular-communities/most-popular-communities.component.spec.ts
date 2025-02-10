import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MostPopularCommunitiesComponent } from './most-popular-communities.component';

describe('MostPopularCommunitiesComponent', () => {
  let component: MostPopularCommunitiesComponent;
  let fixture: ComponentFixture<MostPopularCommunitiesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MostPopularCommunitiesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MostPopularCommunitiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
