# Conclusion

This assignment provided practical experience in implementing and evaluating logging mechanisms in C#. The primary objective was to understand how multiple users or threads can write log data to files and to analyze the performance implications of different logging approaches.

The assignment began with the implementation of a shared logging system where all users wrote to the same log file. To ensure reliable and thread-safe access, a synchronization mechanism using the `lock` statement was implemented. This prevented simultaneous write operations from corrupting the log file and demonstrated the importance of controlling concurrent access to shared resources.

An alternative logging approach was then developed in which each user wrote to a separate log file. By eliminating contention for a single shared resource, this approach reduced the need for synchronization and improved scalability when handling concurrent write operations.

To simulate multiple users accessing the logging system simultaneously, asynchronous tasks were created using `Task.Run`, and execution was coordinated through `Task.WhenAll`. This provided a realistic demonstration of concurrent file operations and highlighted the challenges associated with shared file access.

Performance measurements were collected using the `Stopwatch` class. By comparing the execution times of logging to a single shared file versus multiple independent files, the assignment demonstrated how resource contention can impact application performance and how architectural decisions influence scalability.

Overall, this assignment helped reinforce the following concepts:

- File operations using `FileStream`
- In-memory buffering using `MemoryStream`
- Thread-safe programming using `lock`
- Concurrent processing with `Task` and `Task.Run`
- Coordinating asynchronous operations using `Task.WhenAll`
- Performance measurement using `Stopwatch`
- Managing shared resources in multi-threaded applications
- Designing scalable and efficient logging systems

This exercise provided a deeper understanding of concurrent file access, synchronization techniques, and logging system design in C#. It demonstrated the importance of balancing correctness, performance, and scalability when multiple users or processes interact with shared resources.