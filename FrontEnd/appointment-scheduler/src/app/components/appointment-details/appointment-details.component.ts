import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppointmentService } from '../../services/appointment.service';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { DatePipe } from '@angular/common';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-appointment-detail',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule
  ],
  templateUrl: './appointment-details.component.html',
  styleUrls: ['./appointment-details.component.css'],
  providers: [DatePipe]
})
export class AppointmentDetailComponent implements OnInit {
  appointment: any;

  constructor(
    private appointmentService: AppointmentService,
    private route: ActivatedRoute,
    private router: Router,
    private datePipe: DatePipe,
    public dialogRef: MatDialogRef<AppointmentDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  ngOnInit(): void {
    const id = this.data.id || this.route.snapshot.params['id'];
    this.appointmentService.getAppointment(id).subscribe(
      data => {
        this.appointment = data;
        console.log('Data received:', data);
      },
      error => console.error('Error fetching appointment:', error)
    );
  }

  editAppointment(): void {
    this.dialogRef.close();
    this.router.navigate([`/appointments/edit/${this.appointment.id}`]);
  }

  close(): void {
    this.dialogRef.close();
  }
}
