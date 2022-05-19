# Shopbridge
A simple CRUD API for Inventory management.

## Technical Specification
1. DDD based approach
2. CQRS and Mediator pattern defined in the Shopbridge Framework project. But due to time constraint not implemented in the controller.
3. Fluent Validation is used for model validation.
4. LINQ Expressions used for model -> domain -> entity -> domain -> model data transfer and Parameter Expressions are used for query filters.
5. Entity Framework ORM used as InMemory data store.
6. Scrutor is used for automated DI.
7. Unit of Work, Repository, Mediator, CQRS patterms are used in the code.

## API Documentation - Swagger UI - for testing the API

https://localhost:44334/index.html

## Schemma of Inventory Model<br />
{<br />
id	        :integer($int32)<br />
status	    :boolean<br />
name	      :string nullable    : true<br />
description	:string nullable    : true<br />
price	      :number($double)<br />
}<br />

## List of APIs
1. POST
2. GET
3. DELETE
4. GET{id}
5. PUT{id}
6. GET (grid paging)
7. PATCH (Deactivate)
