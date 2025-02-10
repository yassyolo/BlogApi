import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonalAchievementsComponent } from './personal-achievements.component';

describe('PersonalAchievementsComponent', () => {
  let component: PersonalAchievementsComponent;
  let fixture: ComponentFixture<PersonalAchievementsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PersonalAchievementsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PersonalAchievementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
