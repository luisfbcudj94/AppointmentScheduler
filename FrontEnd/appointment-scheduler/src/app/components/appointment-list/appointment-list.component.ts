import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { AppointmentService } from '../../services/appointment.service';
import { AppointmentDetailComponent } from '../appointment-details/appointment-details.component';
import { MatDialog } from '@angular/material/dialog';
import { AppointmentFormComponent } from '../appointment-form/appointment-form.component';

@Component({
  selector: 'app-appointment-list',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatTableModule
  ],
  templateUrl: './appointment-list.component.html',
  styleUrls: ['./appointment-list.component.css']
})
export class AppointmentListComponent implements OnInit {
  appointments: any[] = [];
  displayedColumns: string[] = ['id', 'location', 'date', 'actions'];
  userId: string = localStorage.getItem('userId') || '';

  constructor(
    private appointmentService: AppointmentService, 
    private router: Router,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.loadAppointments();
  }

  loadAppointments(): void {

    this.appointmentService.getAppointments(this.userId).subscribe(
      (data: any[]) => {
        this.appointments = data;
      },
      error => console.error('Error:', error)
    );
  }

  createAppointment(): void {
    const dialogRef = this.dialog.open(AppointmentFormComponent, {
      width: '600px'
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.loadAppointments();
    });
  }

  viewAppointment(id: string): void {
    const dialogRef = this.dialog.open(AppointmentDetailComponent, {
      width: '600px',
      data: { id: id }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.loadAppointments()
    });
  }

  deleteAppointment(id: string): void {
    this.appointmentService.deleteAppointment(id).subscribe(() => {
      this.loadAppointments();
      window.location.reload();
    }, error => console.error(error));
  }
}
