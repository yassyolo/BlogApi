import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BoomarkFolderListComponent } from './boomark-folder-list.component';

describe('BoomarkFolderListComponent', () => {
  let component: BoomarkFolderListComponent;
  let fixture: ComponentFixture<BoomarkFolderListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BoomarkFolderListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BoomarkFolderListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
