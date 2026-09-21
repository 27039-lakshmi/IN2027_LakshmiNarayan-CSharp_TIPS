# Pattern Matching with Shapes

## Overview

A simple C# console application that demonstrates **Pattern Matching** using a hierarchy of shape classes. The application identifies the runtime type of each shape and displays its specific properties and calculated area using a `switch` statement.

## Features

- Inheritance using a base `Shape` class
- Runtime type identification
- Pattern matching with `switch`
- Area calculation for different shapes
- Polymorphic object handling
- Console-based output

## Project Structure

```text
PatternMatching
│
├── Shape.cs
├── Rectangle.cs
├── Triangle.cs
├── Circle.cs
├── Program.cs
└── README.md
```

## Concepts Demonstrated

- Pattern Matching
- Inheritance
- Runtime Type Checking
- Switch Statements
- Polymorphism
- Object-Oriented Programming (OOP)

## Sample Output

```text
Shape Rectangle Length 5 Breadth 10 Area 50
Shape Triangle Base 3 Height 8 Area 12
Shape Circle Radius 7 Area 153.86
```

## Technologies Used

- C#
- .NET Console Application
- Object-Oriented Programming (OOP)

## Conclusion

This project demonstrates how C# pattern matching can be used to determine an object's runtime type and execute type-specific logic. By combining inheritance and pattern matching, the application provides a clean and maintainable approach to working with different shape objects while calculating and displaying their areas.