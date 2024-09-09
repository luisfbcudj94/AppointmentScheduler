import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { AppointmentService } from '../../services/appointment.service';
import { AppointmentDetailComponent } from '../appointment-details/appointment-details.component';
import { MatDialog } from '@angular/material/dialog';

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

  constructor(
    private appointmentService: AppointmentService, 
    private router: Router,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.loadAppointments();
  }

  loadAppointments(): void {
    this.appointmentService.getAppointments().subscribe(
      (data: any[]) => {
        this.appointments = data;
        console.log('Data received:', data);
      },
      error => console.error('Error:', error)
    );
  }

  viewAppointment(id: string): void {
    const dialogRef = this.dialog.open(AppointmentDetailComponent, {
      width: '600px',
      data: { id: id }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  deleteAppointment(id: string): void {
    this.appointmentService.deleteAppointment(id).subscribe(() => {
      this.loadAppointments();
    }, error => console.error(error));
  }
}
