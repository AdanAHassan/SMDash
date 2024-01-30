import { TestBed } from '@angular/core/testing';

import { PlatformDatasetService } from './platform-dataset.service';

describe('PlatformDatasetService', () => {
  let service: PlatformDatasetService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlatformDatasetService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
