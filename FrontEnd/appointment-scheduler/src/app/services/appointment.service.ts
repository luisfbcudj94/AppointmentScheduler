import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { Appointment } from '../models/appointment';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {
  private apiUrl = 'https://localhost:7070/api';

  constructor(
    private http: HttpClient,
    private router: Router
  ) {}

  private getHeaders(): HttpHeaders {
    const token = localStorage.getItem('token');
    let headers = new HttpHeaders();
    
    if (token) {
      headers = headers.set('Authorization', `Bearer ${token}`);
    } else {
      this.router.navigate(['/login']);
    }
    
    return headers;
  }

  getAppointments(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Appointment`, { headers: this.getHeaders() })
      .pipe(catchError(this.handleError.bind(this)));
  }

  getAppointment(id: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/Appointment/${id}`, { headers: this.getHeaders() })
      .pipe(catchError(this.handleError.bind(this)));
  }

  createAppointment(appointment: Appointment): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/Appointment`, appointment, { headers: this.getHeaders() })
      .pipe(catchError(this.handleError.bind(this)));
  }

  updateAppointment(id: string, appointment: Appointment): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/Appointment/${id}`, appointment, { headers: this.getHeaders() })
      .pipe(catchError(this.handleError.bind(this)));
  }

  deleteAppointment(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/Appointment/${id}`, { headers: this.getHeaders() })
      .pipe(catchError(this.handleError.bind(this)));
  }

  private handleError(error: any) {
    console.error('An error occurred', error);
    return throwError(error);
  }
}

