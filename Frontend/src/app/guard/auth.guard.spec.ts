import { TestBed } from '@angular/core/testing';
import { AuthGuard } from './auth.guard';


describe('AuthGuarde', () => {
  let service: AuthGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthGuard);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
