import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopUsersComponent } from './top-users.component';

describe('TopUsersComponent', () => {
  let component: TopUsersComponent;
  let fixture: ComponentFixture<TopUsersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TopUsersComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TopUsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
