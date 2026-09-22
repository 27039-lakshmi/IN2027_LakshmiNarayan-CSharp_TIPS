# Task 3: Advanced Understanding and Usage of Multi-Threading

## Description

This task demonstrates how to use multiple threads in C# to perform different operations concurrently. Separate threads execute independent tasks simultaneously, and the results are combined and displayed after all threads have completed execution.

---

## Steps

1. Create a new C# Console Application.
2. Define two or more methods that perform independent operations such as mathematical calculations, data processing, or other tasks.
3. Create separate threads using the `Thread` class to execute these operations concurrently.
4. Start all threads and use the `Join` method to wait for their completion.
5. Combine the results from each operation and display them in the console.

---

## Expected Outcome

When the application runs:

- Multiple operations are executed simultaneously on separate threads.
- The main thread waits for all worker threads to complete using the `Join` method.
- Results from all operations are combined and displayed in the console.
- The application demonstrates concurrent execution using multi-threading.

---

## Concepts Covered

- `Thread`
- Multi-Threading
- Concurrent Execution
- `Start()`
- `Join()`
- Shared Data
- Thread Synchronization

---

## Learning Outcome

This task helped in understanding how multi-threading works in C#. By creating and managing multiple threads, independent operations can be executed concurrently, improving resource utilization and reducing overall execution time for suitable workloads. Using the `Join` method ensures that the main thread waits for all worker threads to finish before processing or displaying the final results.