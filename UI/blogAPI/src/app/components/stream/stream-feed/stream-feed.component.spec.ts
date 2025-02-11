import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StreamFeedComponent } from './stream-feed.component';

describe('StreamFeedComponent', () => {
  let component: StreamFeedComponent;
  let fixture: ComponentFixture<StreamFeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StreamFeedComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StreamFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
