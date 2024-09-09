import { Location } from './location';

export interface Appointment {
    id: string;
    locationId: string;
    customerId: string;
    appointmentDate: string;
    status: string;
    location: Location;
  }
  