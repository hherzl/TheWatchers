import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WatcherList } from './watcher-list';

describe('WatcherList', () => {
  let component: WatcherList;
  let fixture: ComponentFixture<WatcherList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WatcherList],
    }).compileComponents();

    fixture = TestBed.createComponent(WatcherList);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
