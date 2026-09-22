# Task 1: Understanding and Implementing Async/Await

## Description

This task demonstrates how to use the `async` and `await` keywords in C# to perform asynchronous operations without blocking the main thread. Content is downloaded from a URL using the `HttpClient` class and displayed in the console.

---

## Steps

1. Create a new C# Console Application.
2. Implement a method that downloads content from a URL using the `HttpClient` class and returns the content as a string.
3. Use the `async` keyword to declare the method and the `await` keyword to asynchronously wait for the download operation to complete.
4. Call the method from the `Main` method and display the downloaded content in the console.

---

## Expected Outcome

When the application runs:

- The content from the specified URL is downloaded asynchronously.
- The downloaded content is displayed in the console.
- The application remains responsive while waiting for the download operation to complete.

---

## Concepts Covered

- `async`
- `await`
- `Task<T>`
- `HttpClient`
- Asynchronous Programming
- Non-Blocking Operations

---

## Learning Outcome

This task helped in understanding how asynchronous programming works in C#. Using `async` and `await` allows long-running operations such as network requests to execute without blocking the application's main thread, resulting in better responsiveness and improved user experience.