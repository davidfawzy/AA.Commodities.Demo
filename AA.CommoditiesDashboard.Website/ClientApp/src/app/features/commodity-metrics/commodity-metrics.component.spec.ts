/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CommodityMetricsComponent } from './commodity-metrics.component';
import { CommodityService } from 'src/app/core/services/commodity/commodity.service';
import { of } from 'rxjs';

describe('CommodityMetricsComponent', () => {
  let component: CommodityMetricsComponent;
  let fixture: ComponentFixture<CommodityMetricsComponent>;
  let service: CommodityService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CommodityMetricsComponent ],
      imports:[],
      providers:[{ provide: CommodityService, useValue: {
        getPnlYTDMetrics:() => of([{"id":1,"name":"Commodity1","metrics":[{"year":2018,"cummulativePnl":2496768.07,"modelResults":[{"id":1,"date":"2018-01-02T00:00:00","contractId":19,"price":31495.72,"positionId":2,"newTradeActionId":1,"pnlDaily":15183.69,"contract":{"id":19,"name":"MAR 18"},"position":{"id":2,"name":"1"},"newTradeAction":{"id":1,"name":"0"}}]}]}])
      } }]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CommodityMetricsComponent);
    component = fixture.componentInstance;
    service = TestBed.get(CommodityService);
    fixture.detectChanges();
  });

  it('should load commodity ', () => {
    spyOn(service,'getPnlYTDMetrics')
    .and
    .callThrough();
    component.ngOnInit();
    fixture.detectChanges();
    expect(service.getPnlYTDMetrics).toHaveBeenCalled();
    expect(component.lineChartData.datasets[0].data.length > 1);
  });
});
