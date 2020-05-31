import { TestBed } from '@angular/core/testing';

import { IonicGestureConfigService } from './ionic-gesture-config.service';

describe('IonicGestureConfigService', () => {
  let service: IonicGestureConfigService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IonicGestureConfigService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
