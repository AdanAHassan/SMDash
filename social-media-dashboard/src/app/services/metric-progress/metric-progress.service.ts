import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MetricProgressService {

  private _serverUrl: string = "http://localhost:5235/api/MetricProgress"

  constructor(private http: HttpClient) { }

  getMetricProgressData(id: number): Observable<any> {
    return this.http.get(`${this._serverUrl}/${id}`).pipe(map(res => res || []))
  }

  getMetricProgressByParentId(parentId: number): Observable<any> {
    return this.http.get(`${this._serverUrl}/ByMetricId/${parentId}`).pipe(map(res => res || []))
  }

}
