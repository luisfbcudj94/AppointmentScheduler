

# Technical Report: Appointment Scheduling System

## Introduction

This report details the implementation of the appointment scheduling system for an entity. The solution consists of a REST API developed in .NET and a web application in Angular. The API handles appointment management, user authentication, and branch management, while the web application allows users to interact with the system to book and manage appointments.

## Application Overview

The appointment scheduling application includes a predefined set of data for locations, users, and roles, allowing for an effective initial setup of the system. In the API, you can see the creation of users and the assignment of roles, highlighting two main roles: **User** and **Admin**. A user with the **User** role can create up to five appointments per day and can only view their own scheduled appointments. On the other hand, a user with the **Admin** role has full access to view all appointments of all users and make necessary modifications. The application implements a robust authentication and authorization system using JWT to ensure secure access and data management.

## Solution Structure

### API

The API solution is divided into several projects, each with specific responsibilities:

#### 1. `AppointmentScheduler.API`

- **Responsibility**: Contains controllers that expose REST endpoints for appointment management, authentication, and branches.
- **Controllers**:
  - `AppointmentController`: Manages CRUD operations and appointment activation.
  - `AuthController`: Manages user authentication using JWT.
  - `LocationController`: Provides information about branches.

#### 2. `AppointmentScheduler.Application`

- **Responsibility**: Implements business logic and services. Contains DTOs (Data Transfer Objects), mapping profiles, and service interfaces.
- **Services and Interfaces**:
  - `IAppointmentService`, `ILocationService`, `IAuthService`: Interfaces defining service contracts.
  - Implementations in `AppointmentService`, `LocationService`, and `AuthService`.

#### 3. `AppointmentScheduler.Domain`

- **Responsibility**: Defines the domain models of the system, representing entities and their behavior.

#### 4. `AppointmentScheduler.Infrastructure`

- **Responsibility**: Manages data persistence, including `DbContext`, migrations, repositories, and interfaces.
- **Repositories and Interfaces**:
  - `IAppointmentRepository`, `ILocationRepository`, `IUserRepository`: Interfaces for CRUD operations.
  - Implementations in `AppointmentRepository`, `LocationRepository`, and `UserRepository`.

#### 5. `AppointmentScheduler.Tests`

- **Responsibility**: Contains unit tests to ensure code quality. Uses xUnit as the testing framework.

### Architecture and Design Patterns

#### Layered Architecture

The solution is structured in layers to promote separation of concerns and facilitate maintenance and scalability:
- **Presentation Layer (API)**: Handles client interaction through controllers.
- **Application Layer**: Contains business logic and services. Uses DTOs to transfer data between layers.
- **Domain Layer**: Defines models and domain logic.
- **Infrastructure Layer**: Manages data persistence and communication with the database. Implements repositories for database interaction and manages EF Core (Entity Framework Core) configuration for data management.
- **Testing Layer**: Contains unit tests for controllers. Uses xUnit to verify the correct functionality of components, ensuring that each unit of code behaves as expected.

#### Design Patterns

1. **Dependency Injection**:
   - Used to decouple components and allow easy replacement of implementations.

2. **Repository Pattern**:
   - Employed to abstract data access, separating business logic from data access.

3. **DTOs (Data Transfer Objects)**:
   - Encapsulate data transferred between layers, improving security and preventing direct exposure of domain models.

4. **Service and Repository Interfaces**:
   - Define contracts for application services and data access operations.

5. **Middlewares**:
   - **CORS**: Allows requests from any origin.
   - **Authentication and Authorization**: Configures JWT handling.
   - **Swagger**: Enabled only in development for API testing and documentation.
   - **HTTPS Redirection**: Redirects all HTTP requests to HTTPS for security.

### Database Design

The database is designed using the Code First approach, allowing the database schema to be generated from the domain models defined in the application.

#### Best Practices in Model Design

1. **Normalization**:
   - Domain models follow normalization principles, minimizing redundancy and improving data integrity.

2. **Decoupling and Modularity**:
   - Models are modular and decoupled, allowing for easy extension and maintenance.

3. **Data Consistency**:
   - Business rules and validations are implemented at the model level to ensure data consistency.

### Unit Testing

- **Test Coverage**: Unit tests are implemented for controllers using xUnit. Tests cover both success and error scenarios to ensure proper handling of requests and errors.

## Web Solution Structure

### Introduction

This report details the implementation of the frontend application for the appointment scheduling system. The application is developed in Angular using TypeScript to define models and ensure type safety.

### Application Structure

#### 1. Components

- `AppointmentDetailComponent`: Displays details of a specific appointment.
- `AppointmentFormComponent`: Allows for creating and editing appointments.
- `AppointmentListComponent`: Displays a list of appointments and allows creation, viewing, and cancellation of appointments.

#### 2. Services

- `AuthService`: Manages user authentication using JWT tokens.
- `AppointmentService`: Manages CRUD operations for appointments.
- `LocationService`: Manages operations related to branches.
- `LoginService`: Handles initial user authentication.

#### 3. Routes

- `routes.ts`: Defines the application's routes and redirects unknown routes to login.

### Architecture and Design Patterns

#### 1. Standalone Components

- Utilizes standalone components to improve modularity and reduce dependencies between modules.

#### 2. Reactive Forms

- Implements reactive forms with integrated validations for creating and editing appointments.

#### 3. Dependency Injection

- Used to decouple services and components, facilitating testing and substitution.

#### 4. API Communication Services

- Encapsulate the logic of API communication, allowing components to interact with data in a decoupled manner.

#### 5. Custom Validations

- Implements custom validations in forms to ensure data quality before sending it to the server.

#### 6. Global and Local State Management

- Uses `localStorage` to store the token and user ID, efficiently managing authentication state.

### User Interface Design

- **Material Design**: Utilizes Angular Material to provide a consistent and modern visual experience.
