# Memory Optimization in C#: A Practical Assignment 3

## Overview

This assignment focuses on identifying, fixing, and analyzing memory-related issues in a C# application. The goal is to understand how memory is allocated on the managed heap, how the Garbage Collector (GC) works, and how memory profiling tools can help optimize application performance.

---

# Task 1: Detecting Memory Issues

## Problem

The application continuously allocates memory and stores references in a list.

```csharp
memAlloc.Add(new int[1000]);
```

As the list keeps growing, the allocated arrays remain referenced and cannot be garbage collected, leading to continuous heap growth and potential memory exhaustion.

## Outcome

- Identified uncontrolled memory allocation.
- Diagnosed memory growth using Visual Studio Diagnostic Tools.
- Observed increasing heap usage due to retained object references.

---

# Task 2: Implementing Memory Management Best Practices

## Solution

- Added a heap memory limit.
- Stopped allocations once the limit is reached.
- Released references by setting the collection to `null`.
- Triggered garbage collection for demonstration purposes.

## Best Practices Applied

- Controlled memory allocation.
- Released unused references.
- Reduced risk of memory leaks.
- Improved application stability.

---

# Task 3: Memory Profiling

## Before Optimization

### Original Implementation

The application continuously allocated memory and stored references in a collection.

```csharp
private readonly List<int[]> memAlloc = new();

while (true)
            {
                this._memAlloc.Add(new int[1000]);

                Console.WriteLine(
                    $"Heap Used: {GC.GetTotalMemory(false) / 1024.0 / 1024.0:F2} MB");

                Thread.Sleep(1000);
            }
```

### Issues Identified

- Memory allocations continued indefinitely.
- References were retained in the collection.
- The Garbage Collector could not reclaim allocated arrays because they were still referenced.
- Heap memory usage continuously increased.


### Outcome

- Continuous heap growth was observed.
- Increasing number of live objects remained in memory.
- Risk of memory exhaustion increased over time.

---

## After Optimization

### Optimized Implementation

A memory threshold was introduced to limit allocations. References were released after use and garbage collection was triggered for demonstration purposes.

```csharp
while (true)
            {
                if (GC.GetTotalMemory(false) > limitBytes)
                {
                    break;
                }

                this._memAlloc!.Add(new int[1000]);
                Console.WriteLine(
                    $"Heap Used: {GC.GetTotalMemory(false) / 1024.0 / 1024.0:F2} MB");
                Thread.Sleep(1000);
            }
```

### Improvements Made

- Added a heap memory limit.
- Stopped allocations when the threshold was reached.
- Released object references after processing.
- Allowed the Garbage Collector to reclaim memory.


---

## Profiling Comparison

| Metric | Before Optimization | After Optimization |
|----------|----------|----------|
| Heap Growth | Continuous | Controlled |
| Live Objects | Increasing | Released after use |
| Memory Consumption | High | Reduced |
| Garbage Collection Efficiency | Limited by retained references | Improved |
| Risk of Memory Exhaustion | High | Low |
| Application Stability | Degrades over time | Improved |

## Outcome

Memory profiling showed that heap growth was significantly reduced after optimization. Once references were released, unused objects became eligible for garbage collection, resulting in a lower memory footprint and improved application stability.

---

# Task 4: Reflection

Through this assignment, I learned how unmanaged memory allocation can negatively affect application performance. When memory is continuously allocated inside a loop without any stopping condition, heap memory usage keeps increasing, which can eventually slow down the application and lead to memory-related issues.

I also learned how to use the `GC.GetTotalMemory()` method to monitor the amount of heap memory being used at a given point in time. This information can be used to implement a memory threshold and stop allocations before memory consumption becomes excessive.

Another important takeaway was understanding object references and garbage collection. Even though .NET has an automatic Garbage Collector, objects cannot be collected if references to them are still maintained. In the original implementation, arrays were continuously added to a collection and their references remained active, preventing the Garbage Collector from reclaiming memory.

The most challenging part was understanding why memory usage continued to grow even though the application was running in a managed environment. Through profiling and analysis, I realized that memory leaks in managed applications are often caused by unintended object retention rather than the absence of garbage collection.

Overall, this assignment helped me understand heap memory behavior, garbage collection, object lifetimes, and the importance of releasing references when objects are no longer needed. These concepts are essential for building efficient and high-performance C# applications.

---

# Conclusion





---


# C# OOP Assignments

## Overview

This project contains three console-based applications developed using C# to demonstrate core Object-Oriented Programming (OOP) concepts

The project is divided into three tasks:

1. Shape Hierarchy
2. Employee Hierarchy
3. Banking System

---

# Task 1: Shape Hierarchy

## Objective

Design a shape management system that calculates the area of different shapes and displays their details.

## Classes Implemented

### Shape (Abstract Class)

#### Property
- Color

#### Methods
- CalculateArea()
- PrintDetails()

### Rectangle (Derived Class)

#### Properties
- Length
- Breadth

#### Functionality
- Calculates area using:

```text
Area = Length × Breadth
```

- Displays:
  - Shape Type
  - Color
  - Area

### Circle (Derived Class)

#### Property
- Radius

#### Functionality
- Calculates area using:

```text
Area = ? × Radius²
```

- Displays:
  - Shape Type
  - Color
  - Area

### Concepts Demonstrated

- Abstract Classes
- Method Overriding
- Inheritance
- Runtime Polymorphism

---

# Task 2: Employee Hierarchy

## Objective

Build an employee management system where different employee types calculate bonuses differently.

## Classes Implemented

### Employee (Abstract Class)

#### Properties
- Name
- Salary

#### Methods
- CalculateBonus()
- PrintDetails()

### Developer (Derived Class)

#### Bonus Calculation

```text
Bonus = Salary / 10
```

#### Displays

- Employee Name
- Position: Developer
- Salary
- Bonus

### Manager (Derived Class)

#### Bonus Calculation

```text
Bonus = Salary / 30
```

#### Displays

- Employee Name
- Position: Manager
- Salary
- Bonus

### Concepts Demonstrated

- Abstraction
- Inheritance
- Method Overriding
- Polymorphism

---

# Task 3: Banking System

## Objective

Create a banking system that supports different account types with customized withdrawal rules.

## Classes Implemented

### BankAccount (Abstract Class)

#### Properties
- AccountNumber
- Balance

#### Methods
- Deposit()
- Withdraw()

### SavingsAccount (Derived Class)

#### Withdrawal Rule

A withdrawal is allowed only if the remaining balance is greater than or equal to the minimum balance.

```text
Remaining Balance ? 1000
```

### CheckingAccount (Derived Class)

#### Withdrawal Rule

Withdrawals are allowed as long as sufficient balance is available.

```text
Withdrawal Amount ? Current Balance
```

### Features

- Account Creation
- Deposit Operations
- Withdrawal Operations
- Account Number Validation
- Balance Validation

### Concepts Demonstrated

- Abstraction
- Inheritance
- Encapsulation
- Method Overriding
- Polymorphism

---

# Project Structure

```text
Assignments
?
??? ShapesManager
?   ??? Models
?   ??? Services
?   ??? View
?
??? EmployeeManager
?   ??? Models
?   ??? Services
?   ??? View
?
??? BankApplication
?   ??? Models
?   ??? Services
?   ??? View
?
??? Program.cs
```

---

# Key Learning Outcomes

Through these assignments, the following C# concepts were practiced:

- Creating Abstract Classes
- Implementing Inheritance Hierarchies
- Applying Polymorphism
- Encapsulating Data Using Properties
- Separating Responsibilities Using Models, Services, and View Layers
- Input Validation
- Building Console Applications

---

# Technologies Used

- C#
- .NET Console Applications
- Object-Oriented Programming (OOP)

---

# Conclusion

These three assignments provide practical experience in designing and implementing object-oriented solutions in C#. The Shape Hierarchy focuses on geometric calculations, the Employee Hierarchy demonstrates role-based bonus calculations, and the Banking System showcases real-world account management with customized business rules.
This assignment demonstrated how improper object retention can lead to excessive memory usage. By controlling allocations, releasing unused references, and profiling application behavior, memory consumption was significantly improved, resulting in a more efficient and stable C# application.