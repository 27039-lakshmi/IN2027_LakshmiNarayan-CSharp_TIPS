## Project Overview

This solution demonstrates various exception handling concepts in C# using Clean Architecture principles. Each task is implemented as a separate Console Application project to provide clear separation of concepts and responsibilities.

---

# Solution Structure

```text
ExceptionHandlingSolution
│
├── Task1.TryCatchFinally
│
├── Task2.CatchingAndThrowingExceptions
│
├── Task3.CustomExceptionHandling
│
├── Task4.GlobalUnhandledExceptions
│
├── Task5.StackTraceAnalysis
│
└── README.md
```

---

# Architecture Approach

Each project follows a simplified Clean Architecture structure.

```text
TaskX
│
├── Domain
│   └── Exceptions
│
├── Application
│   └── Services
│
└── Presentation
    └── Program.cs
```

### Domain Layer

Contains:

- Custom Exceptions
- Business Rules

### Application Layer

Contains:

- Core Logic
- Exception Handling Logic

### Presentation Layer

Contains:

- Console User Interface
- Program Entry Point

---

# Task 1: Understanding and Using try/catch/finally Blocks

## Project Name

```text
Task1.TryCatchFinally
```

## Objective

Demonstrate the usage of:

- try block
- catch block
- finally block

while performing a division operation.

## Architecture

```text
Program.cs
      ↓
Task1Service
```

## Workflow

1. Perform division operation.
2. Attempt to divide by zero.
3. Catch DivideByZeroException.
4. Display an error message.
5. Execute finally block.

## Expected Output

```text
Error: Cannot divide by zero.

Finally block executed.
```

---

# Task 2: Catching and Throwing Different Types of Exceptions

## Project Name

```text
Task2.CatchingAndThrowingExceptions
```

## Objective

Demonstrate:

- IndexOutOfRangeException
- Throwing a new Exception
- Catching the newly thrown Exception

## Architecture

```text
Program.cs
      ↓
Task2Service
```

## Workflow

1. Create an integer array.
2. Access an invalid index.
3. Catch IndexOutOfRangeException.
4. Throw a new Exception with custom message.
5. Catch the new Exception.
6. Display the message.

## Expected Output

```text
Custom Exception:
Array index is outside the valid range.
```

---

# Task 3: Defining and Using Custom Exception Classes

## Project Name

```text
Task3.CustomExceptionHandling
```

## Objective

Create and use a custom exception named:

```text
InvalidUserInputException
```

## Architecture

```text
Program.cs
      ↓
Task3Service
      ↓
InvalidUserInputException
```

## Workflow

1. Accept user input.
2. Validate input.
3. Throw InvalidUserInputException for invalid values.
4. Catch the custom exception.
5. Display custom error message.

## Expected Output

```text
Please enter a valid integer value.
```

## Domain Layer

Contains:

```text
InvalidUserInputException.cs
```

---

# Task 4: Handling Global Unhandled Exceptions

## Project Name

```text
Task4.GlobalUnhandledExceptions
```

## Objective

Demonstrate global exception handling using:

```csharp
AppDomain.CurrentDomain.UnhandledException
```

## Architecture

```text
Program.cs
      ↓
Task4Service
      ↓
Unhandled Exception
      ↓
Global Handler
```

## Workflow

1. Register global exception handler.
2. Execute a method that throws an exception.
3. Do not catch it locally.
4. Let AppDomain handle it.
5. Display global error message.

## Expected Output

```text
Global Exception Handler Invoked

Unhandled Exception:
Something unexpected occurred.
```

---

# Task 5: Using Global Exception Handler and Stack Trace Analysis

## Project Name

```text
Task5.StackTraceAnalysis
```

## Objective

Demonstrate:

- Throwing exceptions
- Catching exceptions
- Reading Stack Trace
- Understanding execution flow

## Architecture

```text
Program.cs
      ↓
Task5Service
      ↓
Throw Exception
      ↓
Catch Exception
      ↓
Display Stack Trace
```

## Workflow

1. Throw an exception.
2. Catch the exception.
3. Print exception message.
4. Print stack trace.
5. Analyze method call sequence.

## Expected Output

```text
Exception Message:
Demo exception generated.

Stack Trace:

at Task5Service.ThrowException()
at Program.Main()
```
