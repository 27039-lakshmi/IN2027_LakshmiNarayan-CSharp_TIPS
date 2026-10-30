# Anonymous Method Array Sorting

## Overview

A simple C# console application that demonstrates the use of an **Anonymous Method** to sort an array of integers in ascending order. The application utilizes the `Array.Sort()` method along with an anonymous delegate to define the comparison logic and display the sorted array.

## Features

- Integer array declaration and initialization
- Use of `Array.Sort()` for sorting
- Anonymous method (delegate) implementation
- Ascending order sorting
- Console output of sorted array

## Project Structure

```text
AnonymousMethodSorting
│
├── Program.cs
└── README.md
```

## Concepts Demonstrated

- Anonymous Methods
- Delegates
- Array Sorting
- `Array.Sort()` Method
- Comparison Logic
- C# Console Applications

## Sample Output

```text
Original Array
5 2 6 4 7

Sorted Array
2 4 5 6 7
```

## Technologies Used

- C#
- .NET Console Application
- Object-Oriented Programming (OOP)

## How It Works

1. An array of integers is declared and initialized.
2. The `Array.Sort()` method is used to sort the array.
3. An anonymous method is passed as the comparison delegate.
4. The anonymous method compares two integers using `CompareTo()`.
5. The array is sorted in ascending order.
6. The sorted array is displayed on the console.

## Conclusion

This project provides a practical demonstration of using anonymous methods in C#. It shows how delegates can be used with the `Array.Sort()` method to define custom comparison logic and sort an array of integers in ascending order.