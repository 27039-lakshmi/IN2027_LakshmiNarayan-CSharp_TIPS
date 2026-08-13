# Expense Tracker

A simple C# console-based Expense Tracker application that allows users to manage income and expense transactions, view transaction history, monitor their financial summary, and persist data using file storage.

---

## Features

- Add Income
- Add Expense
- Edit Income
- Edit Expense
- Delete Income
- Delete Expense
- View Income Records
- View Expense Records
- View Financial Summary
- Automatic Balance Calculation
- Input Validation
- Event-Driven Balance Updates
- File-Based Data Persistence

---

## Project Structure

```text
ExpenseTracker
│
├── Models
│   ├── Transaction.cs
│   ├── Income.cs
│   ├── Expense.cs
│   └── TransactionSummary.cs
│
├── Repository
│   └── TransactionFileRepository.cs
│
├── Service
│   ├── TransactionService.cs
│   └── TransactionEventManager.cs
│
├── View
│   └── ExpenseTrackerView.cs
│
├── Helper
│   ├── Validator.cs
│   └── FileHandler.cs
│
├── Enums
│   ├── MenuOption.cs
│   ├── AddOption.cs
│   ├── EditOption.cs
│   ├── DeleteOption.cs
│   ├── ViewOption.cs
│   └── TransactionType.cs
│
├── Data
│   └── Transactions.json
│
└── Program.cs
```

---

## Technologies Used

- C#
- .NET 6
- Object-Oriented Programming (OOP)
- Event-Driven Programming
- JSON Serialization
- File Handling

---

## Design Overview

### Models

Represents the application entities.

- `Transaction` - Base class for all transactions.
- `Income` - Represents an income transaction.
- `Expense` - Represents an expense transaction.
- `TransactionSummary` - Maintains total income, total expense, and current balance.

### Repository Layer

`TransactionFileRepository` stores and manages transaction records using a JSON file.

**Responsibilities:**

- Load transactions from file
- Save transactions to file
- Update transaction records
- Delete transaction records
- Persist transaction data between application runs

### Service Layer

`TransactionService` contains the business logic.

**Responsibilities:**

- Add transactions
- Update transactions
- Delete transactions
- Calculate totals
- Calculate balance
- Search transactions

### Event Manager

`TransactionEventManager` notifies subscribers whenever transaction data changes.

Whenever a transaction is:

- Added
- Updated
- Deleted

the transaction summary is automatically recalculated.

### View Layer

`ExpenseTrackerView` handles:

- User input
- Menu navigation
- Displaying records
- Displaying summaries

### Validation

`Validator` validates:

- Transaction amount
- Text input
- Date input
- Menu selections

### File Storage

All transaction data is stored in a JSON file. This allows the application to retain records even after it is closed and reopened.

Benefits include:

- Persistent storage
- Lightweight implementation
- Easy maintenance
- No database dependency

---

## Menu Options

```text
1. Add Income/Expense
2. Edit Income/Expense
3. Delete Income/Expense
4. View Income/Expense
5. Get Summary
6. Exit
```

---

## Sample Execution

### Add Income

```text
1. Add Income
2. Add Expense

Enter your choice:
1

Choose your option
1. Enter your own date
2. Today's date

2

Enter income amount:
25000

Enter income source:
Salary

Income added successfully.
```

### View Income

```text
ID: I1
Transaction Date: 10-08-2026
Amount: 25000
Source: Salary
```

### View Summary

```text
Your Summary

Total Income    : 28000
Total Expense   : 5000
Current Balance : 23000
```

---

## Validation Rules

### Date Validation

- Must be a valid date.
- Cannot be a future date.

### Amount Validation

- Must be a valid integer.
- Must be greater than zero.

### Source / Category Validation

- Only alphabets and spaces are allowed.
- Numbers and special characters are not allowed.

---

## Event Flow

```text
Add / Edit / Delete Transaction
                |
                v
Raise TransactionChanged Event
                |
                v
Recalculate