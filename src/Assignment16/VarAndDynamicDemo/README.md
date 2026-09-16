# Understanding var and dynamic Keywords

## Overview

A simple C# console application that demonstrates the differences between `var` and `dynamic` variables.

## Features

- Uses `var` and `dynamic` keywords
- Demonstrates type inference and runtime typing
- Shows type reassignment behavior
- Console-based output

## Concepts Demonstrated

- `var`
- `dynamic`
- Compile-time type checking
- Runtime type resolution

## Sample Output

```text
Using var:
Value: 100, Type: System.Int32

Using dynamic:
Value: 100, Type: System.Int32
Value: Hello World, Type: System.String
```

## Expected Outcome

- `var` does not allow its type to be changed after declaration.
- `dynamic` allows its type to change at runtime.

## Technologies Used

- C#
- .NET Console Application

## Conclusion

This project demonstrates the key difference between `var` and `dynamic`: `var` is type-safe and resolved at compile time, while `dynamic` is flexible and resolved at runtime.
