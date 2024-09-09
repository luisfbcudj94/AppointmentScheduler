import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7070/api/Auth';

  constructor(private http: HttpClient) {}

  getToken(cedula: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/login`, { cedula });
  }
}
