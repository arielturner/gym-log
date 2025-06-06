import { TestBed } from '@angular/core/testing';

import { BodyPartsService } from './body-parts.service';

describe('BodyPartsService', () => {
  let service: BodyPartsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BodyPartsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
