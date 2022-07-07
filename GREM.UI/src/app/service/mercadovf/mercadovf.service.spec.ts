import { TestBed } from '@angular/core/testing';

import { MercadovfService } from './mercadovf.service';
//src\app\service\cliente



describe('MercadovfService', () => {
  let service: MercadovfService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MercadovfService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
