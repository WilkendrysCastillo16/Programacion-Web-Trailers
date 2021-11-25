import { TestBed } from '@angular/core/testing';

import { ServicefirstService } from './servicefirst.service';

describe('ServicefirstService', () => {
  let service: ServicefirstService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServicefirstService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
