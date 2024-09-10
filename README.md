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

![Untitled-2024-05-20-2144(2)](https://github.com/user-attachments/assets/b8a26476-d336-425e-9957-a2a39b3a0639)


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

- Product Service: `http://localhost:5248/swagger`
- Basket Service: `http://localhost:5265/swagger`

![Production](https://github.com/user-attachments/assets/3f918a69-059f-4550-b8c9-ead76cfd200f)

![Basket](https://github.com/user-attachments/assets/cec4b3b1-41ea-4209-999f-af89464cfbe7)


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

## Application Flow
# E-commerce Microservices Project

[Önceki içerik aynı kalacak...]

## Application Flow

Here are some screenshots demonstrating the core functionalities of our e-commerce platform:

### 1. Adding a Product

![AddProduct](https://github.com/user-attachments/assets/85bf3839-fa0f-43b0-b22e-08f53ba8d263)

![MongoDb](https://github.com/user-attachments/assets/3d2eb6f5-266f-45f5-a928-b3495800de5c)


This screenshot shows the process of adding a new product to our catalog using the Product Service API.

### 2. Adding an Item to the Basket

![addBasket](https://github.com/user-attachments/assets/e9d5bbb5-9a03-41c5-86f9-718bd4cb90ea)


Here, you can see how a user can add an item to their shopping cart using the Basket Service API.

### 3. Viewing the Basket

![basketredis](https://github.com/user-attachments/assets/d68b99bc-9d2d-417a-8b67-6c0c18e18e26)


This image demonstrates how the contents of a user's shopping cart are displayed.

### 4. Stock Depletion Event and RabbitMQ Dashboard

![rabbitMq](https://github.com/user-attachments/assets/56616ec1-3bb0-4537-a29c-8355695f74e1)

![endBasket](https://github.com/user-attachments/assets/0b5cd6e1-0515-46d2-987e-e0485c19fe57)


This is the RabbitMQ management interface, showing the queues and message rates for our stock depletion events.When a product's stock runs low, our system automatically generates an event using RabbitMQ. This screenshot shows the event being published and consumed.


## How It Works

1. **Product Management**: 
   - Administrators can add, update, or remove products using the Product Service API.
   - Product information is stored in MongoDB.

2. **Shopping Cart Operations**:
   - Users can add products to their cart, update quantities, or remove items using the Basket Service API.
   - Basket data is stored in Redis for fast access and updates.

3. **Stock Management**:
   - When a product is added to a cart, the system checks the available stock.
   - If the stock falls below a certain threshold, a "Low Stock" event is published to RabbitMQ.




