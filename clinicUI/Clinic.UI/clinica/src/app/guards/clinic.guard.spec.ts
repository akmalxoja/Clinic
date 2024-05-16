import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { clinicGuard } from './clinic.guard';

describe('clinicGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => clinicGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
