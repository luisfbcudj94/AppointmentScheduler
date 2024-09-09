import { Location } from './location';

export interface Appointment {
    id: string;
    locationId: string;
    cedula: string;
    appointmentDate: string;
    status: string;
    location: Location;
    isActive: boolean;
    createdAt: string;
    activatedAt: string;
  }
  