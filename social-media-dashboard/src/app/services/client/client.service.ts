import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  private _serverUrl: string = "http://localhost:5235/api/Client"

  constructor(private http: HttpClient) { }

  getPaginatedClients(pageIndex: number, pageSize: number): Observable<any> {
    return this.http.get(`${this._serverUrl}/Paginated/${pageIndex}/${pageSize}`).pipe(map(res => res || []))
  }

  getClientData(id: number): Observable<any> {
    return this.http.get(`${this._serverUrl}/${id}`).pipe(map(res => res || []))
  }

  getClientIds(): Observable<any> {
    return this.http.get(`${this._serverUrl}/IdList`).pipe(map(res => res || []))
  }
}

