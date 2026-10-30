# Advanced Delegates Product Sorting System

## Overview

A simple C# console application that demonstrates the use of **Delegates** to perform custom sorting operations on a collection of products. Users can sort products by different criteria such as Name, Category, and Price without changing the core sorting logic.

## Features

- Custom delegate implementation
- Sorting products by Name
- Sorting products by Category
- Sorting products by Price
- Reusable sorting logic
- Console-based output

## Project Structure

```text
AdvancedDelegates
│
├── Product.cs
├── Program.cs
└── README.md
```

## Concepts Demonstrated

- Delegates
- Lambda Expressions
- Generic Collections (`List<T>`)
- Custom Sorting
- Separation of Concerns
- Object-Oriented Programming (OOP)

## Sample Output

```text
Sort by Name

Product Name Apple Product Category Fruit Product Price 100
Product Name Guava Product Category Fruit Product Price 200
Product Name Harry Potter Product Category Book Product Price 1000
Product Name Iphone Product Category Smartphone Product Price 100000
Product Name Victus Product Category Laptop Product Price 200000
```

## Technologies Used

- C#
- .NET Console Application
- Object-Oriented Programming (OOP)

## Conclusion

This project demonstrates how delegates can be used to create flexible and reusable sorting mechanisms. By passing different comparison methods as delegates, the same sorting logic can be applied to multiple product attributes, improving code maintainability and extensibility.