import { TestBed } from '@angular/core/testing';
import { LinhacapService } from './linhacap.service';

describe('LinhacapService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LinhacapService = TestBed.get(LinhacapService);
    expect(service).toBeTruthy();
  });
});
