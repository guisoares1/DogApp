# DogApp

DogApp is a system that allows displaying, filtering, and updating data about dogs, designed with a modern architecture and following best development practices. This repository contains both the backend and frontend of the application.

## Technologies Used
### External APIs
- **Dog API**: Data about dogs is retrieved using the [Dog API](https://dogapi.dog/docs/api-v2) to populate the application.
### Backend
- **.NET**: API development using the **DDD (Domain-Driven Design)** pattern, ensuring a well-structured and organized architecture.
- **Hangfire**: Background task implementation for automatically updating data every hour.
- **Entity Framework Core**: Database management.
- **SQL Server**: Relational database used to store information.

### Frontend
- **Vue.js**: Reactive and interactive user interface, developed using **TypeScript** for increased robustness and code safety.
- **Tailwind CSS**: Fast and efficient styling, ensuring a clean and responsive design.
- **Axios**: API consumption for displaying and updating data in the interface.

## Features

### Backend
- **Automatic Data Update**: Hangfire is used to execute scheduled tasks that automatically update the data every hour.
- **DDD Organization**: Implementation following the Domain-Driven Design model for easier maintenance and expansion.

### Frontend
- **Data Display**: List of dogs with information such as name, maximum and minimum lifespan, description, and whether they are hypoallergenic.
- **Filtering**: Ability to filter displayed data based on specific criteria.
- **API Integration**: Real-time data updates through API consumption created in the backend.

## Project Structure

The project is organized into multiple layers, following a clean architecture approach:

### Backend
- **Application**: Handles use cases and application logic.
- **CrossCutting**: Contains shared implementations and dependencies across layers, such as dependency injection, configurations, and utilities.
- **Domain**: Core of the system, including entities, interfaces, and business rules.
- **Infrastructure**: Implements interfaces defined in the domain layer, such as repositories and integrations with external frameworks or services.
- **WebApi**: Presentation layer exposing endpoints for interaction with the frontend or other consumers.
- **WorkerService**: Background service, primarily used for scheduled tasks like Hangfire to perform periodic updates.

### Frontend
The frontend structure uses best practices for organization with Vue.js:
- **Components**: Componentization for easy reuse and maintenance.
- **Views**: Main pages of the application.
- **Services**: API consumption.

## How to Run the Project

### Backend
1. Clone the repository.
2. Configure the database connection string in the `appsettings.json` file.
3. Run the Entity Framework migration commands:
   ```bash
   dotnet ef database update
   ```
4. Start the application:
   ```bash
   dotnet run
   ```

### Frontend
1. Navigate to the frontend folder.
2. Install the dependencies:
   ```bash
   npm install
   ```
3. Start the development server:
   ```bash
   npm run dev
   ```
## Demo Video


https://github.com/user-attachments/assets/30495f53-f319-4555-a651-f3fbd36b325a



For more information, get in touch through my [GitHub](https://github.com/guisoares1).

