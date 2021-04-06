import { TestBed } from '@angular/core/testing';

import { FiberService } from './fiber.service';

describe('FiberService', () => {
  let service: FiberService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FiberService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
