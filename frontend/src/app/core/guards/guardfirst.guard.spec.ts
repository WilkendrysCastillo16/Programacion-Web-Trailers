import { TestBed } from '@angular/core/testing';

import { GuardfirstGuard } from './guardfirst.guard';

describe('GuardfirstGuard', () => {
  let guard: GuardfirstGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(GuardfirstGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
