**Contact Manager (Console Application)**



**Overview**



Contact Manager is a console-based application developed using C# that allows users to manage their contacts efficiently. The application follows a 3-Layer Architecture consisting of View, Service, and Repository layers to ensure separation of concerns and maintainable code.



---



**Features**



- Add a new contact

- Edit an existing contact

- Delete a contact

- Search a contact using its unique ID

- Display all contacts

- Support multiple phone numbers for a contact

- Support multiple email IDs for a contact

- Automatically generate a unique GUID for every contact



---






**Project Structure**



ContactsManager

│

├── Models

│   └── Contact.cs

│

├── Repository

│   └── ContactRepository.cs

│

├── Service

│   └── ContactService.cs

│

├── View

│   └── ContactView.cs

│

├── Program.cs

│

└── README.md



---









**Contact Model**



**Each contact contains:**



- GUID (Unique Identifier)

- Name

- Multiple Phone Numbers

- Multiple Email IDs



---



**Functionalities**



**Add Contact**



Creates a new contact with:



- Auto-generated GUID

- Name

- One or more phone numbers

- One or more email IDs







**Edit Contact**



Updates an existing contact using its GUID.







**Delete Contact**



Removes a contact using its GUID.







**Search Contact**



Searches for a contact using its GUID and displays all details.







**Display All Contacts**



Displays every contact stored in the application.



---







**Design Principles**



- Three-layer architecture

- Separation of concerns

- Modular and maintainable code

- Simple and user-friendly console interface

- Automatic GUID generation for unique contact identification



---






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
Area = π × Radius²
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
Remaining Balance ≥ 1000
```

### CheckingAccount (Derived Class)

#### Withdrawal Rule

Withdrawals are allowed as long as sufficient balance is available.

```text
Withdrawal Amount ≤ Current Balance
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
│
├── ShapesManager
│   ├── Models
│   ├── Services
│   └── View
│
├── EmployeeManager
│   ├── Models
│   ├── Services
│   └── View
│
├── BankApplication
│   ├── Models
│   ├── Services
│   └── View
│
└── Program.cs
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