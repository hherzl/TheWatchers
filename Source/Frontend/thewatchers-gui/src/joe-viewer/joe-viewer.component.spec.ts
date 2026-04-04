import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';

import { JoeViewerComponent } from './joe-viewer.component';

describe('JoeViewerComponent', () => {
  let component: JoeViewerComponent;
  let fixture: ComponentFixture<JoeViewerComponent>;

  beforeEach(() => {
    fixture = TestBed.createComponent(JoeViewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
