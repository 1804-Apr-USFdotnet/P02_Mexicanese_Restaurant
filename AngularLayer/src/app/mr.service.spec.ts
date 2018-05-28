import { TestBed, inject } from '@angular/core/testing';

import { MRService } from './mr.service';

describe('MRService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MRService]
    });
  });

  it('should be created', inject([MRService], (service: MRService) => {
    expect(service).toBeTruthy();
  }));
});
