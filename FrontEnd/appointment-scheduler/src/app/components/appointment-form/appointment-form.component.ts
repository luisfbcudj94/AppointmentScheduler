import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { AppointmentService } from '../../services/appointment.service';
import { LocationService } from '../../services/location.service';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { Location } from '../../models/location';
import { Appointment } from '../../models/appointment';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-appointment-form',
  standalone: true,
  templateUrl: './appointment-form.component.html',
  styleUrls: ['./appointment-form.component.css'],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatSelectModule 
  ]
})
export class AppointmentFormComponent implements OnInit {
  appointmentForm: FormGroup;
  isEdit = false;
  locations: Location[] = [];
  appointment: Appointment = {} as Appointment;

  constructor(
    private fb: FormBuilder,
    private appointmentService: AppointmentService,
    private locationService: LocationService,
    public dialogRef: MatDialogRef<AppointmentFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.appointmentForm = this.fb.group({
      locationId: ['', Validators.required],
      date: ['', Validators.required],
      appointmentId: [''],
      userId: [localStorage.getItem('userId') || '']
    });
  }

  ngOnInit(): void {

    this.locationService.getLocations().subscribe(
      data => {
        this.locations = data;
      },
      error => console.error('Error fetching locations:', error)
    );

    if (this.data && this.data.id) {

      this.isEdit = true;

      this.appointmentService.getAppointment(this.data.id).subscribe(
        data => {
          this.appointment = data;
          const formattedDate = new Date(data.appointmentDate).toISOString().slice(0, 16);
          this.appointmentForm.patchValue({
            locationId: data.locationId,
            date: formattedDate,
            appointmentId: data.id
          });
        },
        error => console.error('Error fetching appointment:', error)
      );
      
    }
  }

  onSubmit(): void {

    this.appointment.locationId = this.appointmentForm.value.locationId;
    this.appointment.appointmentDate = this.appointmentForm.value.date;
    this.appointment.userId = localStorage.getItem('userId') || '';

    if (this.isEdit) {

      if (this.appointment.locationId != this.appointment.location.id){

        this.locationService.getLocation(this.appointment.locationId).subscribe(
          data => {
            this.appointment.location = data;
            this.appointmentService.updateAppointment(this.appointment.id, this.appointment).subscribe(() => {
              this.dialogRef.close(true);
              window.location.reload();
            }, error => console.error(error));
          },
          error => console.error('Error fetching locations:', error)
        );

      }
      else{

        this.appointmentService.updateAppointment(this.appointment.id, this.appointment).subscribe(() => {
          this.dialogRef.close(true);
          window.location.reload();
        }, error => console.error(error));
      }

    } else {

      this.appointment.isActive = true;
      this.appointment.createdAt = new Date().toISOString().slice(0, 16);
      this.appointment.activatedAt = new Date().toISOString().slice(0, 16);

      this.appointmentService.createAppointment(this.appointment).subscribe(() => {
        this.dialogRef.close(true);
      }, error => console.error(error));
    }
  }

  close(): void {
    this.dialogRef.close();
  }
}
