import { TestBed, inject } from '@angular/core/testing';

import { ServiciosService } from './servicios.service';

describe('ServiciosService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ServiciosService]
    });
  });

  it('should be created', inject([ServiciosService], (service: ServiciosService) => {
    expect(service).toBeTruthy();
  }));
});
