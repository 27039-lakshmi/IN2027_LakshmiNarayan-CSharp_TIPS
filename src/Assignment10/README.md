# Calculator Application (Console Application)

## Overview

Calculator Application is a console-based application developed using C# that allows users to perform basic arithmetic operations. The application follows a 3-Layer Architecture consisting of Presentation, Application, and Domain layers to ensure separation of concerns and maintainable code.

---

## Features

- Perform Addition
- Perform Subtraction
- Perform Multiplication
- Perform Division
- Input validation for menu selection
- Input validation for operands
- Maximum retry attempts for invalid integer inputs
- Exception handling for division by zero
- Enum-based operation management
- Simple console-based user interface

---

## Project Structure

```text
Calculator
│
├── Domain
│   └── Enums
│       └── CalculatorOperation.cs
│
├── Application
│   └── Service
│       └── MathUtils.cs
│
├── Presentation
│   └── Controller
│       └── MathUtilController.cs
│
├── Program.cs
│
└── README.md
```

---

## Calculator Operations

### Supported Operations

- Addition
- Subtraction
- Multiplication
- Division
- Exit

---

## Functionalities

### Addition

Adds two integer values entered by the user and displays the result.

#### Example

```text
Input:
10
20

Output:
Sum: 30
```

---

### Subtraction

Subtracts the second operand from the first operand and displays the result.

#### Example

```text
Input:
20
10

Output:
Difference: 10
```

---

### Multiplication

Multiplies two integer values and displays the result.

#### Example

```text
Input:
5
4

Output:
Product: 20
```

---

### Division

Divides the first number by the second number and displays the quotient.

#### Example

```text
Input:
20
4

Output:
Quotient: 5
```

If the divisor is zero, the application displays an appropriate error message.

```text
Divisor should not be zero
```

---

### Exit

Terminates the calculator application.

```text
Exiting
```

---

## Input Validation

### Menu Validation

The application validates the selected operation before processing.

```text
Invalid Choice
```

is displayed when the entered choice is not valid.

---

### Operand Validation

The application accepts only valid integer inputs.

For invalid inputs:

```text
It should be a valid integer
```

is displayed.

Users are provided with a maximum of three attempts per operand.

After three unsuccessful attempts:

```text
Maximum number of tries reached
```

is displayed and the operation is cancelled.

---

## Architecture

### Presentation Layer

Responsible for:

- Displaying the menu
- Accepting user inputs
- Validating inputs
- Displaying results and error messages

**Class**

```text
MathUtilController
```

---

### Application Layer

Responsible for:

- Performing arithmetic operations
- Encapsulating business logic

**Class**

```text
MathUtils
```

Methods:

- PerformAddition()
- PerformSubtraction()
- PerformMultiplication()
- PerformDivision()

---

### Domain Layer

Responsible for:

- Defining application-specific enums and entities

**Enum**

```text
CalculatorOperation
```

Values:

```text
Add
Subtract
Multiplication
Division
Exit
Invalid
```

---

## Design Principles

- Three-layer architecture
- Separation of concerns
- Clean and maintainable code
- Reusable business logic
- Console-based user interaction
- Input validation
- Exception handling
- Enum-driven operation management

---

## Exception Handling

The application handles division-by-zero scenarios gracefully.

```csharp
catch (DivideByZeroException)
{
    Console.WriteLine("Divisor should not be zero");
}
```

This prevents