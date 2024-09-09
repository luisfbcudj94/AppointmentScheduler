import { Role } from './role';

export interface User {
    id: string;
    name: string;
    cedula: string;
    role: Role
}
