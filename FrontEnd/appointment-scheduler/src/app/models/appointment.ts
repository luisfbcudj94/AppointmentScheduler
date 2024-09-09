import { Location } from './location';
import { User } from './user';

export interface Appointment {
    id: string;
    locationId: string;
    userId: string;
    appointmentDate: string;
    status: string;
    location: Location;
    user: User;
    isActive: boolean;
    createdAt: string;
    activatedAt: string;
  }
  