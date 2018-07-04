import { TestBed, inject } from '@angular/core/testing';

import { CurdSnackService } from './curd-snack.service';

describe('CurdSnackService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CurdSnackService]
    });
  });

  it('should be created', inject([CurdSnackService], (service: CurdSnackService) => {
    expect(service).toBeTruthy();
  }));
});
