# Advanced LINQ Challenges

## Overview

This solution demonstrates the implementation of various LINQ concepts ranging from basic querying operations to advanced query building techniques using the Fluent API Pattern.

The project is structured using a simplified Clean Architecture approach with separate Presentation and Application layers for each task. Each task is implemented as an independent project to ensure separation of concerns, maintainability, and ease of testing.

---

## Solution Structure

```text
AdvancedLinqChallenges
â
âââ Task1.BasicQueries
â   âââ Presentation
â   âââ Application
â
âââ Task2.ComplexQueries
â   âââ Presentation
â   âââ Application
â
âââ Task3.LinqToObjects
â   âââ Presentation
â   âââ Application
â
âââ Task4.PerformanceOptimization
â   âââ Presentation
â   âââ Application
â
âââ Task5.QueryBuilder
    âââ Presentation
    âââ Application

# Task Descriptions

## Task 1: Basic LINQ Queries

### Objective

This task focuses on fundamental LINQ operations such as filtering, projection, sorting, and aggregation. Using a collection of products, LINQ queries are used to retrieve Electronics products priced above $500, display selected properties, sort the results by price, and calculate the average price.

### Concepts Covered

- `Where`
- `Select`
- `OrderByDescending`
- `Average`
- LINQ Method Syntax
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

## Task 2: Complex LINQ Queries
# Conclusion

### Objective

This task extends basic LINQ capabilities by performing grouping and joining operations. Products are grouped by category to calculate product counts and identify the most expensive product within each category. An inner join is also performed between products and suppliers to establish relationships between datasets.

### Concepts Covered

- `GroupBy`
- `Count`
- `OrderByDescending`
- `First`
- `Join`
- Query Expressions

---

## Task 3: LINQ to Objects

### Objective
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

This task focuses on working with in-memory collections such as arrays. LINQ is used to determine the second highest number in a collection and to identify all unique pairs of numbers whose sum equals a specified target value.

### Concepts Covered
```text
Area = ? × Radius²
```

- `Distinct`
- `OrderByDescending`
- `Skip`
- `First`
- Cross Joins using LINQ
- LINQ Query Syntax


---

## Task 4: Performance Considerations with LINQ

### Objective

This task highlights the performance implications of LINQ query execution. A comparison is made between a non-optimized query and an optimized query that leverages deferred execution and avoids unnecessary materialization of data.

### Concepts Covered

- Deferred Execution
- Immediate Execution
- `ToList()`
- Query Optimization
- Memory Efficiency


---

## Task 5: Fluent Query Builder

### Objective

This task involves designing and implementing a reusable Query Builder utility using the Fluent API pattern. The utility supports dynamic filtering, sorting, joining, and execution of LINQ queries while providing an expressive and readable interface through method chaining.

### Concepts Covered

- Fluent API Pattern
- Method Chaining
- Expression Trees
- Generic Programming
- Dynamic Query Generation
- LINQ Extensibility

```text
Remaining Balance ? 1000
```

### CheckingAccount (Derived Class)

#### Withdrawal Rule

Withdrawals are allowed as long as sufficient balance is available.

```text
Withdrawal Amount ? Current Balance
```
### Expected Outcome

Demonstrates advanced LINQ knowledge by creating a flexible, reusable, and maintainable query-building framework capable of constructing complex queries dynamically.

---

### Exploration

I have explored about using IList instead of List. IList can be used while declaring lists so that if there is a change in requirement to use different collection then
its enough to only change the concrete part of the declaration . As all the other methods will be dependent on IList the entire code need not change when we use
different collection. Instead of directly depending on a concrete implementation of collection if we use IList it creates a contract that the objects will follow.
This promotes the flexibility and maintainability.

---
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
