import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';

import { WatcherCreateComponent } from './watcher-create.component';

describe('WatcherCreateComponent', () => {
  let component: WatcherCreateComponent;
  let fixture: ComponentFixture<WatcherCreateComponent>;

  beforeEach(() => {
    fixture = TestBed.createComponent(WatcherCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
