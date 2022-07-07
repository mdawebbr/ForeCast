import { TestBed } from '@angular/core/testing';
import { MercadocapService } from './mercadocap.service';

describe('MercadocapService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MercadocapService = TestBed.get(MercadocapService);
    expect(service).toBeTruthy();
  });
});
