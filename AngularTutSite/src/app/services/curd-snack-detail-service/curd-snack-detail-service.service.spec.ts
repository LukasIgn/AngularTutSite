import { TestBed, inject } from '@angular/core/testing';

import { CurdSnackDetailServiceService } from './curd-snack-detail-service.service';

describe('CurdSnackDetailServiceService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CurdSnackDetailServiceService]
    });
  });

  it('should be created', inject([CurdSnackDetailServiceService], (service: CurdSnackDetailServiceService) => {
    expect(service).toBeTruthy();
  }));
});
