# Task 2: Implementing and Understanding Task Parallel Library

## Description

This task demonstrates how to use the Task Parallel Library (TPL) in C# to perform operations on multiple data items concurrently. The `Parallel.ForEach` method is used to process an array of integers and calculate the square of each number. The execution time of the parallel implementation is then compared with a traditional sequential approach to understand the benefits and limitations of parallel programming.

---

## Steps

1. Create a new C# Console Application.
2. Define and initialize an array of integers (for example, from 0 to 9999).
3. Implement a method that processes the array sequentially and measures its execution time.
4. Implement a method that processes the same array using `Parallel.ForEach` and measures its execution time.
5. Calculate the square of each number in the array and display the results in the console.
6. Compare and display the execution times of both approaches.

---

## Expected Outcome

When the application runs:

- The square of each number in the array is calculated and displayed.
- The sequential execution time is measured and displayed.
- The parallel execution time is measured and displayed.
- The behavior and performance differences between sequential and parallel execution can be observed.

---

## Concepts Covered

- Task Parallel Library (TPL)
- `Parallel.ForEach`
- Parallel Programming
- Thread Pool
- Concurrency
- Performance Measurement
- `Stopwatch`

---

## Learning Outcome

This task helped in understanding how the Task Parallel Library can be used to execute operations concurrently across multiple threads. It demonstrated how `Parallel.ForEach` distributes work among available ThreadPool threads and highlighted the importance of choosing appropriate workloads for parallel execution. The exercise also showed that parallel processing can improve performance for computationally intensive tasks, while introducing overhead that may make it less efficient for simple or resource-contention-heavy operations such as console output.