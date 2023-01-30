import { TestBed } from '@angular/core/testing';

import { VenueServicesService } from './venue-services.service';

describe('VenueServicesService', () => {
  let service: VenueServicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VenueServicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
