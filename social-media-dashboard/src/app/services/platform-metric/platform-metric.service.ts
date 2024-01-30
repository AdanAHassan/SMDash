import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PlatformMetricService {

  private _serverUrl: string = "http://localhost:5235/api/PlatformMetric"

  constructor(private http: HttpClient) { }

  getPlatformMetricData(id: number): Observable<any> {
    return this.http.get(`${this._serverUrl}/${id}`).pipe(map(res => res || []))
  }

  getPlatformMetricByParentId(parentId: number): Observable<any> {
    return this.http.get(`${this._serverUrl}/RenderedByDatasetId/${parentId}`).pipe(map(res => res || []))
  }

}
