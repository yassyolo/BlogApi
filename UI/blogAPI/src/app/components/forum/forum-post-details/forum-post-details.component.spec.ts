import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ForumPostDetailsComponent } from './forum-post-details.component';

describe('ForumPostDetailsComponent', () => {
  let component: ForumPostDetailsComponent;
  let fixture: ComponentFixture<ForumPostDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ForumPostDetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ForumPostDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
