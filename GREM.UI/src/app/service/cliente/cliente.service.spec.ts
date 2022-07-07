import { TestBed } from '@angular/core/testing';

import { ClienteService } from './cliente.service';
//src\app\service\cliente



describe('ClienteService', () => {
  let service: ClienteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClienteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
