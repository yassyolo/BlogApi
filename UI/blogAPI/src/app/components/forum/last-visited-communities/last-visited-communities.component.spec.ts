import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LastVisitedCommunitiesComponent } from './last-visited-communities.component';

describe('LastVisitedCommunitiesComponent', () => {
  let component: LastVisitedCommunitiesComponent;
  let fixture: ComponentFixture<LastVisitedCommunitiesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LastVisitedCommunitiesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LastVisitedCommunitiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
