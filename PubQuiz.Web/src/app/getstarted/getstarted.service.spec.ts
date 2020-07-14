import { TestBed } from '@angular/core/testing';

import { GetstartedService } from './getstarted.service';

describe('GetstartedService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: GetstartedService = TestBed.get(GetstartedService);
    expect(service).toBeTruthy();
  });
});
