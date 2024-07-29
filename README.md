# StradaTechnicalInterview

[![Build Status](https://img.shields.io/badge/build-passing-brightgreen.svg)](https://github.com/RanielQuirante/transport-system)

## Introduction

This project is a .NET 8.0 based application that demonstrates a repository pattern implementation using several technologies and design patterns. It includes features such as fluent validation, automapper, dependency injection, and database interactions.

## Technologies Used

- .NET 8.0
- FluentValidation
- AutoMapper
- MSSQL
- Entity Framework Core (EF Core)
- Repository Pattern

## Project Structure

- **Api Project**
  - Contains Controllers

- **Infrastructures Project**
  - Contains Entities and ApplicationDbContext

- **Services Project**
  - Contains Service Implementations

- **Repositories Project**
  - Contains Repository Implementations

- **Models Project**
  - Contains DTOs (Data Transfer Objects) with Request and Response folders
  - Contains Entities folder

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- MSSQL Server

### Setup

1. Clone the repository to your local machine:
   ```sh
   git clone https://github.com/RanielQuirante/StradaTechnicalInterview.git

2. From the Package Manager Console, target the Infrastructure project

3. Enter the following command to update the database:
   ```sh
   Update-Database

### Running the Application
1. Open the solution in Visual Studio.
2. Set the Api project as the startup project.
3. Run the application.

### Dependency Injection
Dependency injection is configured inside the Program.cs file in the Api project. All necessary services, repositories, and validators are registered here.

### Repositories
- Repositories are responsible for communicating directly with the ApplicationDbContext.
- The repository pattern is implemented to provide a clean separation of concerns between data access and business logic.

### Services
- Services are responsible for business logic and interact with repositories.
- Validators from FluentValidation are used within services to ensure data integrity.
