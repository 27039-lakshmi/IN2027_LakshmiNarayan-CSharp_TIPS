# Records Demo

## Overview

A simple C# console application that demonstrates the use of **Records** introduced in **C# 9.0**. The application creates and manipulates `Book` records to showcase features such as value equality, immutability, deconstruction, and the `with` expression.

## Features

- Record creation and initialization
- Displaying record details
- Value-based equality comparison
- Immutability using `init` properties
- Record cloning with the `with` keyword
- Record deconstruction

## Project Structure

```text
RecordsDemo
│
├── Book.cs
├── Program.cs
└── README.md
```

## Concepts Demonstrated

- Records
- Value Equality
- Immutability
- Deconstruction
- With Expressions
- Object-Oriented Programming (OOP)

## Sample Output

```text
Book Title: Ln Author: C# ISBN: 5
Book Title: Db Author: Python ISBN: 8
Book Title: Harini Author: C++ ISBN: 10
Book Title: Db Author: Python ISBN: 8

Are books equal? True

Original Book:
Book { Title = Db, AuthorName = Python, ISBN = 8 }

Modified Book:
Book { Title = Ln, AuthorName = Python, ISBN = 8 }

Title: Db
Author: Python
ISBN: 8
```

## Technologies Used

- C#
- .NET Console Application
- Records (C# 9.0+)
- Object-Oriented Programming (OOP)

## Conclusion

This project demonstrates the advantages of records in C#, including value-based equality, immutability, automatic deconstruction, and simplified object copying using the `with` keyword. It provides a practical introduction to working with immutable data models in modern C# applications.