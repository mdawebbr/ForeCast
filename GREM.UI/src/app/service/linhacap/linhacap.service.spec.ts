import { TestBed } from '@angular/core/testing';

import { LinhacapService } from './linhacap.service';

describe('LinhacapService', () => {
  let service: LinhacapService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LinhacapService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
