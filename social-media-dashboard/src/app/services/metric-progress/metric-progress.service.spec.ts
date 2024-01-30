import { TestBed } from '@angular/core/testing';

import { MetricProgressService } from './metric-progress.service';

describe('MetricProgressService', () => {
  let service: MetricProgressService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MetricProgressService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
