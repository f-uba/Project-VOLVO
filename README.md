# Clean Architecture Project

This project is based on the Clean Architecture principles presented by Jason Taylor. For more information, you can visit [Jason Taylor's Clean Architecture](https://jasontaylor.dev/clean-architecture-getting-started/).

## Project Structure

- **Domain**: Contains the core entities and data transfer objects (DTOs) that represent the business model.
- **Application**: Implements the business logic, including entity mappings, interfaces, handlers, and commands using the Mediator pattern.
- **Infrastructure**: Manages data persistence, including repositories and other data-related services.
- **API**: Exposes the application functionality through controllers, providing endpoints for client interaction.
- **xUnitTests**: The project includes a set of unit tests to ensure the correctness of the application logic.

## Getting Started

To run the project, follow these steps:

1. **Install .NET SDK** (if not already installed):
    - You can download and install the .NET SDK from [here](https://dotnet.microsoft.com/download).
      
2. **Clone the repository**: git clone https://github.com/f-uba/Project-VOLVO.git
      
3. **Navigate to the project root directory**

4. **Run the API project via CMD or GitBash on the project root directory**: dotnet run --project API

5. **Open your browser and navigate to the Swagger UI**: http://localhost:5294/swagger

   - This will allow you to interact with the API endpoints.

6. **Run the unit tests**: dotnet tests
