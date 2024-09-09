import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LocationService {
  private apiUrl = 'https://localhost:7070/api';

  constructor(private http: HttpClient) { }

  getLocations(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Location`);
  }

  getLocation(id: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/Location/${id}`);
  }
}
