/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CommodityService } from './commodity.service';

describe('Service: CommodityService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CommodityService]
    });
  });

  xit('should ...', inject([CommodityService], (service: CommodityService) => {
    expect(service).toBeTruthy();
  }));
});
