E-Commerce Web Application:
Description:
  This project is a simplified e-commerce web application built using ASP.NET Core API, Entity Framework Core, and SQL Server. The application is designed to provide basic functionalities for managing products,     customers, and orders.
Features:
  Product Management: Add, update, delete, and list products.
  Customer Management: Register,login.
  Order Management: Add, update, delete, and list orders.
  API Endpoints: RESTful APIs for seamless integration with frontend systems.
  Database: SQL Server used for data storage with EF Core for database interaction.

Technologies Used
  Backend: ASP.NET Core API
  ORM: Entity Framework Core
  Database: SQL Server
  Development Environment: Visual Studio 2022
Prerequisites:
  .NET SDK: Version 8.0 or higher
  SQL Server: Local or cloud-hosted instance
  Visual Studio: Or any code editor with .NET support
  Postman: For testing API endpoints (optional)

Installation:
  Clone the repository:

  git clone https://github.com/MaryamAkramAbdAlazeem/EcommerceProkoders
  cd simplified-ecommerce
Configure the database connection:

  Open appsettings.json.
  Update the connection string under "ConnectionStrings":
  json
  
  "DefaultConnection": "Server=YOUR_SERVER;Database=ECommerceDB;Trusted_Connection=True;"
Run the application:

  dotnet run
API Documentation:
  The API documentation can be accessed through Swagger. After running the application, open your browser and navigate to:
  
  https://localhost:44325/swagger

Database Schema
  The database consists of the following tables:
  
  Products: Stores product details (e.g., Name, Price, Quantity).
  Users: Stores customer information (e.g., Name, Email).
  Orders: Stores order details, including customer and product associations.

Future Enhancements
  Authentication & Authorization: Secure APIs using JWT.
  Pagination: Add pagination to API endpoints for listing resources.
  Advanced Filtering: Allow filtering and sorting of products.
  Frontend Integration: Develop a React/Angular-based frontend.
