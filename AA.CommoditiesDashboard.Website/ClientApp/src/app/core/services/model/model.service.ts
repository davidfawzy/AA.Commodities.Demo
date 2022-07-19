import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ModelService {

  constructor(private httpclient: HttpClient) { }

  getYearlyPnLPriceMetrics(): Observable<any[]> {
    return this.httpclient.get<any[]>(`${environment.baseApi}/Model/YearlyPnLPriceMetrics`)
  }
}
