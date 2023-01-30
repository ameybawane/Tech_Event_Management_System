import { TestBed } from '@angular/core/testing';

import { SpeakerServicesService } from './speaker-services.service';

describe('SpeakerServicesService', () => {
  let service: SpeakerServicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SpeakerServicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
