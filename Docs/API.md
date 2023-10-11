# StackedAPI Docs

# Products

## Introduction

The ProductsAPI is an API for managing and retrieving information about products. This documentation provides details on the available endpoints and how to use them.

## Base URL

The base URL for accessing the API is `/api/products`.

## Endpoints

### Get All Products

- **URL:** `/`
- **Method:** GET
- **Description:** Retrieve a list of all products.
- **Response:**
  - Status Code: 200 OK
  - Body: An array of product objects.

### Get Product by ID

- **URL:** `/products/{id}`
- **Method:** GET
- **Description:** Retrieve a specific product by its ID.
- **Parameters:**
  - `id` (integer, required): The unique identifier of the product.
- **Response:**
  - Status Code: 200 OK (if found)
  - Status Code: 404 Not Found (if not found)
  - Body: A product object.

### Create a New Product

- **URL:** `/products`
- **Method:** POST
- **Description:** Create a new product.
- **Request:**
  - Content-Type: application/json
  - Body: Product object (name, description, price, etc.).
- **Response:**
  - Status Code: 201 Created (if the product is successfully created)
  - Status Code: 400 Bad Request (if the request is invalid)
  - Status Code: 500 Internal Server Error (for other errors)
  - Body: The created product object.
