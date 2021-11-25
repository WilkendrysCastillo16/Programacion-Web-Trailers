import { TestBed } from '@angular/core/testing';

import { ServiceshareService } from './serviceshare.service';

describe('ServiceshareService', () => {
  let service: ServiceshareService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServiceshareService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
