import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommunitiesForFeedComponent } from './communities-for-feed.component';

describe('CommunitiesForFeedComponent', () => {
  let component: CommunitiesForFeedComponent;
  let fixture: ComponentFixture<CommunitiesForFeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CommunitiesForFeedComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CommunitiesForFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
