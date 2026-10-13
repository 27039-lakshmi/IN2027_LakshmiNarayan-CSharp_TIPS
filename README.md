# CSharpConsoleSolution

## Overview

This assignment demonstrates the creation and management of a multi-project C# solution in Visual Studio. The solution showcases project organization, project references, dependency management, and build order configuration while implementing a calculator application across multiple console projects.

## Objective

The objective of this assignment was to understand:

- Solution management in Visual Studio
- Project references and dependencies
- Build order configuration
- Modular application design
- Code reusability
- Console application development in C#

## Solution Structure

The solution contains five projects:

### Project A - GreetingsApp

Purpose:

- Displays a welcome message.
- Invokes the user interface from DisplayApp.

### Project B - MathApp

Purpose:

Provides arithmetic operations for other projects.

Implemented Methods:

- Add()
- Subtract()
- Multiply()
- Divide()

### Project C - DisplayApp

Purpose:

Provides a console-based calculator interface.

Responsibilities:

- Accepts user input.
- Validates input using UtilityApp.
- Performs calculations using MathApp.
- Displays results.

### Project D - UtilityApp

Purpose:

Provides utility methods used by other projects.

Implemented Utilities:

- Number validation
- Operator validation

### Project E - AdditionalProject

Purpose:

Demonstrates the addition of a new project and dependency management within the solution.

Responsibilities:

- Uses functionality from DisplayApp.
- Verifies updated build-order behavior.

## Project Dependencies

Initial Dependencies:

```text
GreetingsApp
    |
    v
DisplayApp
    |
    v
MathApp
    |
    v
UtilityApp
```

After Adding AdditionalProject:

```text
GreetingsApp
    |
    v
DisplayApp
   / \
  v   v
MathApp AdditionalProject
   |
   v
UtilityApp
```

## Build Order

### Initial Build Order

1. UtilityApp
2. MathApp
3. DisplayApp
4. GreetingsApp

### Updated Build Order

1. UtilityApp
2. MathApp
3. DisplayApp
4. AdditionalProject
5. GreetingsApp

This configuration ensures that dependent projects are built only after their referenced projects have been compiled successfully.

## Implemented Functionalities

### GreetingsApp

- Displays a welcome message.
- Launches the calculator interface.

Example Output:

```text
Welcome to calculator application
```

### MathApp

Provides arithmetic operations.

Example:

```csharp
Calculator.Add(10, 20);
Calculator.Subtract(20, 10);
Calculator.Multiply(10, 5);
Calculator.Divide(20, 4);
```

### DisplayApp

Provides a calculator user interface.

Example Output:

```text
Enter the first number:
10

Enter the second number:
5

Enter the operation (+,-,*,/):


Result: 50
```

### UtilityApp

Provides validation methods.
Example:

```csharp
Validator.IsValidNumber("23"");
Validator.IsValidOperator("+");```

### AdditionalProject

Invoke functionality from DisplayApp.

Example:

```csharp
DisplayApp.ConsoleUI.Start();
```

## Testing

The applications were tested in the following order:

1. GreetingsApp.
2. MathApp
3. DisplayApp
4. AdditionalProject

Verification Performed:

- Project references resolved correctly.
- Build order executed as expected.
- Calculator operations returned accurate results.- Input validation functioned properly.
- AdditionalProject successfuly reused existing functionality.
## Solution Documentation

The following were documented and verified

### Before Modification

- Solution structure
- Project dependencies
- Build order

### After Modification

- Addition of AdditionalProject
- Updated dependencies
- Updated build order

## Key Learnings

This assignment provided practical experience in:

- Creating and managing solutions in Visual Studio
- Configuring project references
- Managing project dependencies
- Understanding build order
- Designing reusable components
- Applying modular programming principles
- Improving maintainability through separation of concerns

# Conclusion

This assignment successfully demonstrated the creation and management of a multi-project C# solution using Visual Studio. Five console applications were organized within a single solution to illustrate project references dependency management, and build-order configuration.

The solution followed a modular architecture where each project had a well-defined responsibility. UtilityApp provided validation functionality, MathApp handled arithmetic operations, DisplayApp managed user interaction, GreetingsApp served as the main entry point, and AdditionalProject demonstrated the integration of an additional project into the existing solution.

Project references and dependencies were configured correctly,ensuring that Visual Studio built rojects in the proper sequence. Ths prevented compilation issues andguaranteed that dependent projectshad access to required assemblies.
The exercise emphasized the imporance of:

- Proper project organiztion
- Solution management
- Depenency configuration
- Build-order control
- Reusability and maintainability
- Scalable application architecture

Overall, this assignment provided valuable hands-on experience in organizing and managing multi-project C# solutions and reinforced best practices for developing reliable, maintainable, and scalable software applications.