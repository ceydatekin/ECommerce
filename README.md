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

![2](https://private-user-images.githubusercontent.com/54938901/366163422-d232c666-f5f1-4b46-99d1-c443d09dac92.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MjU5OTIzOTAsIm5iZiI6MTcyNTk5MjA5MCwicGF0aCI6Ii81NDkzODkwMS8zNjYxNjM0MjItZDIzMmM2NjYtZjVmMS00YjQ2LTk5ZDEtYzQ0M2QwOWRhYzkyLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDA5MTAlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQwOTEwVDE4MTQ1MFomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPThmNzMxNTgwYWY4ZGI0ODY2OTIwZWZiZDI0MDMxMmVlNjY5MjY4ZWI1ZTE0ZjM4ZTBlMmVhNjZhZWMwMzBlMjkmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.1lmOOyBoe63rJJwD4Yelgh0zz494QEcI5dC4BQqg3bA)


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

![Product Service Swagger](https://private-user-images.githubusercontent.com/54938901/366169245-e24594dd-b002-4bba-ac65-0d311b80a715.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MjU5OTM1MTEsIm5iZiI6MTcyNTk5MzIxMSwicGF0aCI6Ii81NDkzODkwMS8zNjYxNjkyNDUtZTI0NTk0ZGQtYjAwMi00YmJhLWFjNjUtMGQzMTFiODBhNzE1LnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDA5MTAlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQwOTEwVDE4MzMzMVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPWRmNDAwNzJkMjI5Y2VlMjA2NjMxMzgzODdkZWI1ZTA5ZWJiOTNiNGYzNWI5MzViOGMwZGQxYTU4YTlhYzkwMjMmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.Dz2KN5O50uHG-P2LlfEudL-6ro-8-ZdntWLrUYQD6pM)

![Basket Service Swagger](https://private-user-images.githubusercontent.com/54938901/366169162-ee44d958-3542-4db4-8a27-e5a86e3b02ce.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MjU5OTM1MTEsIm5iZiI6MTcyNTk5MzIxMSwicGF0aCI6Ii81NDkzODkwMS8zNjYxNjkxNjItZWU0NGQ5NTgtMzU0Mi00ZGI0LThhMjctZTVhODZlM2IwMmNlLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDA5MTAlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQwOTEwVDE4MzMzMVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPWU0ZDg4N2Y4NjlhODExNDY1ZjNkZTY4MzMwODUxNzZiN2QxYjNlNTQ4YWRjYTI3NGQyYWZhMjEyOTc0MTIyN2ImWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.VbmR_Z0wmkBBTT6xXhQ384x8B2Ri1FY-88z8gInKRdk)

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

![Adding a Product](https://private-user-images.githubusercontent.com/54938901/366169172-ba8568a6-c06f-43c3-b603-2063aeb64d9b.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MjU5OTM1MTEsIm5iZiI6MTcyNTk5MzIxMSwicGF0aCI6Ii81NDkzODkwMS8zNjYxNjkxNzItYmE4NTY4YTYtYzA2Zi00M2MzLWI2MDMtMjA2M2FlYjY0ZDliLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDA5MTAlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQwOTEwVDE4MzMzMVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPWRhZjU4M2YxOTRjMjM3MGYyOTJiNmU1ZDNjYzE0M2U1NDVjOGQ2ZmExZjEzNGEyZGU4YmQ3MjhjYWFhMmNmZWEmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.ZUh0icxNnqRSVZsirJG2aQxcamK-pfj7NkJhMdWUzNY)

![Adding a Product](https://private-user-images.githubusercontent.com/54938901/366169179-0ef61345-6da0-4c57-8576-e742502ce0dd.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MjU5OTM1MTEsIm5iZiI6MTcyNTk5MzIxMSwicGF0aCI6Ii81NDkzODkwMS8zNjYxNjkxNzktMGVmNjEzNDUtNmRhMC00YzU3LTg1NzYtZTc0MjUwMmNlMGRkLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDA5MTAlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQwOTEwVDE4MzMzMVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPWQzMTdhMzQ2ZTk0ZWFkNTQ2YzYwODBjMDZmZjM4MDY1ZGZiZjgxM2I5MTBjN2NlZjk5MzUxYmM1NWU4Mjc3NGEmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.jGGdoApZ0pTPbbJ0rLN5K-TzQZJBgJnAKtz6C1i3-K4)


This screenshot shows the process of adding a new product to our catalog using the Product Service API.

### 2. Adding an Item to the Basket

![Adding to Cart](https://private-user-images.githubusercontent.com/54938901/366169191-401e9971-e395-4268-b93f-3b995fdb6acb.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MjU5OTM1MTEsIm5iZiI6MTcyNTk5MzIxMSwicGF0aCI6Ii81NDkzODkwMS8zNjYxNjkxOTEtNDAxZTk5NzEtZTM5NS00MjY4LWI5M2YtM2I5OTVmZGI2YWNiLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDA5MTAlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQwOTEwVDE4MzMzMVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTJmZjNhYmI1ODMyYmZjMmE3MjdmNjA0NzQ4Y2QwOTJjMDE0MWYxN2NiOTQ3MTI2OTU2YmFhNWZjMzk5OWJkOTkmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.0JqYCY1hscVwtfsXM9lugPGP55M4LI5AYIlnVWnnCX8)

Here, you can see how a user can add an item to their shopping cart using the Basket Service API.

### 3. Viewing the Basket

![Viewing the Cart](https://private-user-images.githubusercontent.com/54938901/366169199-a5f07344-ea7c-4136-a458-ec438aed9df6.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MjU5OTM1MTEsIm5iZiI6MTcyNTk5MzIxMSwicGF0aCI6Ii81NDkzODkwMS8zNjYxNjkxOTktYTVmMDczNDQtZWE3Yy00MTM2LWE0NTgtZWM0MzhhZWQ5ZGY2LnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDA5MTAlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQwOTEwVDE4MzMzMVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTUxMWQ5ZDU2ZmZmZTFkY2I1YzVkMGMzNzA0NjM0ZjNjZWE4OTQxNmQzMDNiMGUwY2RjNmZiYTJjMWI2M2FjM2QmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.riU8Kf9PU7SYPKgJO0E8A-bspnZdIKBZU5wNlt7jicQ)

This image demonstrates how the contents of a user's shopping cart are displayed.

### 4. Stock Depletion Event and RabbitMQ Dashboard


![RabbitMQ Dashboard](https://private-user-images.githubusercontent.com/54938901/366169209-8b655137-b9c4-4271-b54b-f33a88ea33bc.png?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MjU5OTM1MTEsIm5iZiI6MTcyNTk5MzIxMSwicGF0aCI6Ii81NDkzODkwMS8zNjYxNjkyMDktOGI2NTUxMzctYjljNC00MjcxLWI1NGItZjMzYTg4ZWEzM2JjLnBuZz9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDA5MTAlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQwOTEwVDE4MzMzMVomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPTQwMDZhOGVhNjdmNTQxYWE3Y2I3ZjY1YTM4M2YxOGM5NTU3MGQ0Mjg2MjQxMThhYjA5M2Y1NjViYWM4ODNhOWMmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.wRg-mMFJGglf4qodCXFZnOUGpIW41U2ucgfi0UNrqTU)

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




