import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Appointment } from '../models/appointment';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {
  private apiUrl = 'https://localhost:7070/api';

  constructor(private http: HttpClient) { }

  getAppointments(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Appointment`);
  }

  getAppointment(id: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/Appointment/${id}`);
  }

  createAppointment(appointment: Appointment): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/Appointment`, appointment);
  }

  updateAppointment(id: string, appointment: Appointment): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/Appointment/${id}`, appointment);
  }

  deleteAppointment(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
