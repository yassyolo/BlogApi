import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommunitiesWithCategoryIdComponent } from './communities-with-category-id.component';

describe('CommunitiesWithCategoryIdComponent', () => {
  let component: CommunitiesWithCategoryIdComponent;
  let fixture: ComponentFixture<CommunitiesWithCategoryIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CommunitiesWithCategoryIdComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CommunitiesWithCategoryIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
