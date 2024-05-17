# JetSetGo

## Description
JetSetGo is an ASP.NET Core application designed to manage flights and booking operations for the travel industry. This system includes functionalities for searching holiday options, booking those options, and checking the status of bookings. The architecture follows Clean Architecture principles, ensuring scalability, maintainability, and separation of concerns.

## Features
### Search Functionality
- Allows users to search for holiday options based on destination and dates.
- Supports different search types including HotelOnly, HotelAndFlight, and LastMinuteHotels.

### Booking Functionality
- Enables users to book selected holiday options.
- Generates unique booking codes for each booking.

### Status Check Functionality
- Allows users to check the status of their bookings (Pending, Success, or Fail).

### Global Exception Handling
- Implements middleware to handle exceptions globally and return standardized error responses.

### Input Validation with FluentValidation
-Uses FluentValidation to enforce validation rules on input models, ensuring data integrity and consistency.

## Technologies Used
- ASP.NET Core 6
- FluentValidation
- Clean Architecture
- Dependency Injection
- Middleware for Global Exception Handling

## Project Structure
### Application
- Contains business logic and application services.
- Includes validators and strategy implementations.

### Domain
- Contains entities, value objects, and domain services.

### Infrastructure
- Contains data access implementations and external service clients.
- Includes middleware for exception handling.

### API (Presentation Layer)
- Contains controllers and API endpoints.
- Configures dependency injection and middleware.

## Installation
### 1. Clone the repository:
`git clone https://github.com/karakulevv/JetSetGo.git`

### 2. Navigate to the project directory:
`cd JetSetGo`

### 3. Restore the dependencies:
`dotnet restore`

### 4. Build the project:
`dotnet build`

### 5. Run the application:
`dotnet run`

## Usage
### Search for Holiday Options:
- Send a POST request to /search with the required parameters.

### Book a Holiday Option:
- Send a POST request to /book with the selected option code.

### Check Booking Status:
- Send a POST request to /checkstatus with the booking code.
