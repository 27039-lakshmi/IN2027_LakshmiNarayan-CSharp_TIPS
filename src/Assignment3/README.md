# Inventory Manager (Console Application)

## Overview

Inventory Manager is a console-based application developed using C# that allows users to manage inventory products efficiently. The application follows a 3-Layer Architecture consisting of View, Service, and Repository layers to ensure separation of concerns and maintainable code.

---

## Features

- Add a new product
- Edit an existing product
- Delete a product
- Search products by name
- Display all products
- Validate product details before adding or updating
- Maintain unique Product IDs
- Track product price and quantity

---

## Project Structure

InventoryManager

│

├── Models

│   └── Product.cs

│

├── Repository

│   └── Inventory.cs

│

├── Services

│   └── InventoryServices.cs

│

├── View

│   └── UserViewer.cs

│

├── Helper

│   ├── Validators.cs

│   └── Messages.resx

│

├── Program.cs

│

└── README.md

---

## Product Model

### Each product contains:

- Product ID
- Product Name
- Product Price
- Product Quantity

---

## Functionalities

### Add Product

Creates a new product with:

- Unique Product ID
- Product Name
- Product Price
- Product Quantity

The application prevents duplicate Product IDs from being added.

---

### Edit Product

Updates an existing product using its Product ID.

Users can modify:

- Product Name
- Product Price
- Product Quantity

---

### Delete Product

Removes a product from the inventory using its Product ID.

---

### Search Product

Searches products by name and displays matching products.

---

### View All Products

Displays all products available in the inventory.

---

## Validation

The application validates:

- Product ID cannot be empty
- Product ID must be unique
- Product Price must be a positive integer
- Product Quantity must not be a negative integer

---

## Design Principles

- Three-layer architecture
- Separation of concerns
- Repository pattern
- Modular and maintainable code
- Input validation
- User-friendly console interface
- Resource file support for messages and prompts

---

## Technologies Used

- C#
- .NET
- Collections (List<T>)
- Resource Files (.resx)
- Object-Oriented Programming (OOP)
