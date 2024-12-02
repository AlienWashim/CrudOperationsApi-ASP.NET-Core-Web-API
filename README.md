# CrudOperationsApi_ASP.NET_Core_Web_API
This project is a demonstration of building a CRUD (Create, Read, Update, Delete) API using ASP.NET Core Web API with MS SQL Server as the database. The project adopts the Database-First Approach to interact with the database and provides RESTful API endpoints for managing Person entities.

## Key Features
**Database Integration**: Utilizes MS SQL Server with the Database-First Approach to generate entity models from the existing database schema.

**Person Table**:
**Columns**: PersonId, Name, Salary

**Sample Data**: Contains information about individuals, such as their ID, name, and salary.

**API Functionality**:
 * GET: Retrieve all records or a specific record by ID.
 * POST: Add a new record to the database.
 * PUT: Update an existing record.
 * DELETE: Remove a record from the database.

## Tools & Technologies Used
ASP.NET Core Web API: Framework for building scalable and efficient APIs.
MS SQL Server: Database management system for storing and managing data.
Swagger: Integrated for API testing and documentation.
Database-First Approach: Models and context are generated directly from the database schema.
API Endpoints

Here are the available endpoints:
* GET /api/person: Retrieve all records.
* GET /api/person/{id}: Retrieve a specific record by ID.
* POST /api/person: Add a new record.
* PUT /api/person/{id}: Update an existing record.
* DELETE /api/person/{id}: Delete a specific record.
