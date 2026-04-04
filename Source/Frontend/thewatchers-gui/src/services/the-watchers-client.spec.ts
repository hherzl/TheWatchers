import { TestBed } from '@angular/core/testing';

import { TheWatchersClient } from './the-watchers-client';

describe('TheWatchersClient', () => {
  let service: TheWatchersClient;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TheWatchersClient);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
