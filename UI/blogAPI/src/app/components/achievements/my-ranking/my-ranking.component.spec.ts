import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyRankingComponent } from './my-ranking.component';

describe('MyRankingComponent', () => {
  let component: MyRankingComponent;
  let fixture: ComponentFixture<MyRankingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MyRankingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyRankingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
