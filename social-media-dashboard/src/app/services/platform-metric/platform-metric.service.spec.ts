import { TestBed } from '@angular/core/testing';

import { PlatformMetricService } from './platform-metric.service';

describe('PlatformMetricService', () => {
  let service: PlatformMetricService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlatformMetricService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
