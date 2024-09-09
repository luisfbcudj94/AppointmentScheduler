import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { AppointmentService } from '../../services/appointment.service';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

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
    MatIconModule
  ]
})
export class AppointmentFormComponent implements OnInit {
  appointmentForm: FormGroup;
  isEdit = false;

  constructor(
    private fb: FormBuilder,
    private appointmentService: AppointmentService,
    public dialogRef: MatDialogRef<AppointmentFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.appointmentForm = this.fb.group({
      location: ['', Validators.required],
      date: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    if (this.data && this.data.id) {
      this.isEdit = true;
      this.appointmentService.getAppointment(this.data.id).subscribe(
        data => this.appointmentForm.patchValue(data),
        error => console.error(error)
      );
    }
  }

  onSubmit(): void {
    if (this.isEdit) {
      this.appointmentService.updateAppointment(this.appointmentForm.value.id, this.appointmentForm.value).subscribe(() => {
        this.dialogRef.close(true);
      }, error => console.error(error));
    } else {
      this.appointmentService.createAppointment(this.appointmentForm.value).subscribe(() => {
        this.dialogRef.close(true);
      }, error => console.error(error));
    }
  }

  close(): void {
    this.dialogRef.close();
  }
}
