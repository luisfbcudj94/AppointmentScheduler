import { AbstractControl, ValidatorFn } from '@angular/forms';

export function dateRangeValidator(): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } | null => {
    const today = new Date();
    const maxDate = new Date();
    maxDate.setDate(today.getDate() + 3);

    const dateValue = new Date(control.value);

    if (dateValue < today || dateValue > maxDate) {
      return { 'dateRange': true };
    }

    return null;
  };
}
