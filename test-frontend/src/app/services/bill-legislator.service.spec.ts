import { TestBed } from '@angular/core/testing';

import { BillLegislatorService } from './bill-legislator.service';

describe('BillLegislatorService', () => {
  let service: BillLegislatorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BillLegislatorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
