import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WatcherDetailsComponent } from './watcher-details.component';

describe('WatcherDetailsComponent', () => {
  let component: WatcherDetailsComponent;
  let fixture: ComponentFixture<WatcherDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WatcherDetailsComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(WatcherDetailsComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
