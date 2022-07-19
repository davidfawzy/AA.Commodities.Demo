import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CommodityService {

  constructor(private httpclient: HttpClient) { }

  getPnlYTDMetrics(): Observable<any[]> {
    return this.httpclient.get<[]>(`${environment.baseApi}/Commodity/PnlYTDMetrics`)
  }

  getMetrics(): Observable<any[]> {
    return this.httpclient.get<any[]>(`${environment.baseApi}/Commodity/Metrics`)
  }
}
