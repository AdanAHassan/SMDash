import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PlatformDatasetService {

  private _serverUrl: string = "http://localhost:5235/api/PlatformDataset"

  constructor(private http: HttpClient) { }

  getPlatformDatasetList(): Observable<any> {
    return this.http.get(`${this._serverUrl}`).pipe(map(res => res || []))
  }

  getPlatformDatasetData(id: number): Observable<any> {
    return this.http.get(`${this._serverUrl}/${id}`).pipe(map(res => res || []))
  }

  getPlatformDatasetByClientId(clientId: number): Observable<any> {
    return this.http.get(`${this._serverUrl}/RenderedByClientId/${clientId}`).pipe(map(res => res || []))
  }

  getPlatformDatasetByClientName(clientName: string): Observable<any> {
    return this.http.get(`${this._serverUrl}/RenderedByClientName/${clientName}`).pipe(map(res => res || []))
  }
}

