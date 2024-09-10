# E-commerce Microservices Project

This project is a microservices-based e-commerce platform that demonstrates the use of various technologies and architectural patterns in a distributed system.

## Project Overview

This e-commerce platform is designed to handle product management and shopping cart functionality. It utilizes a microservices architecture to ensure scalability and maintainability.

Key Features:
- Product catalog management
- Shopping cart functionality
- Real-time stock updates
- Asynchronous communication between services

## Architecture

![Architecture Diagram](https://via.placeholder.com/800x600.png?text=E-commerce+Microservices+Architecture)

The system consists of the following main components:

1. Product Service: Manages product information (MongoDB)
2. Basket Service: Handles shopping cart operations (Redis)
3. RabbitMQ: Message broker for asynchronous communication

## Technologies Used

- .NET 8
- MongoDB
- Redis
- RabbitMQ
- Docker
- Swagger

## Prerequisites

- Docker
- Docker Compose

## Installation and Setup

1. Clone the repository:
   ```
   git clone https://github.com/yourusername/ecommerce-microservices.git
   ```

2. Navigate to the project directory:
   ```
   cd ecommerce-microservices
   ```

3. Run the following command to start all services:
   ```
   docker-compose up -d
   ```

This command will build and start all the necessary containers for the project.

## API Documentation

After starting the services, you can access the Swagger UI for each service:

- Product Service: `http://localhost:5000/swagger`
- Basket Service: `http://localhost:5001/swagger`

![Product Service Swagger](https://via.placeholder.com/800x600.png?text=Product+Service+Swagger)
![Basket Service Swagger](https://via.placeholder.com/800x600.png?text=Basket+Service+Swagger)

## Key Functionalities

1. Product Management:
   - Add, update, and delete products
   - View product details and inventory

2. Shopping Cart:
   - Add products to cart
   - Update quantities
   - Remove products from cart
   - View cart contents

3. Stock Management:
   - Real-time stock updates
   - Notifications when stock is low (via RabbitMQ)

## Development

To develop and extend this project:

1. Ensure you have .NET 6 SDK installed
2. Open the solution in your preferred IDE (e.g., Visual Studio, Rider)
3. Make changes to the services as needed
4. Rebuild the Docker images if you make changes:
   ```
   docker-compose build
   docker-compose up -d
   ```
