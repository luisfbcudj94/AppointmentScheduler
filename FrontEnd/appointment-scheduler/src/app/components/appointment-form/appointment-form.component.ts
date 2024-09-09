import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { AppointmentService } from '../../services/appointment.service';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

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
    MatInputModule
  ]
})
export class AppointmentFormComponent implements OnInit {
  appointmentForm: FormGroup;
  isEdit = false;

  constructor(
    private fb: FormBuilder,
    private appointmentService: AppointmentService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.appointmentForm = this.fb.group({
      location: ['', Validators.required],
      date: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    const id = this.route.snapshot.params['id'];
    if (id) {
      this.isEdit = true;
      this.appointmentService.getAppointment(id).subscribe(
        data => this.appointmentForm.patchValue(data),
        error => console.error(error)
      );
    }
  }

  onSubmit(): void {
    if (this.isEdit) {
      this.appointmentService.updateAppointment(this.appointmentForm.value.id, this.appointmentForm.value).subscribe(() => {
        this.router.navigate(['/appointments']);
      }, error => console.error(error));
    } else {
      this.appointmentService.createAppointment(this.appointmentForm.value).subscribe(() => {
        this.router.navigate(['/appointments']);
      }, error => console.error(error));
    }
  }
}
