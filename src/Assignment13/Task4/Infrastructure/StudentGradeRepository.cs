namespace Task4.Infrastructure
{
    /// <summary>
    /// Represents a generic repository for storing and managing
    /// student grade records using a dictionary.
    /// </summary>
    /// <typeparam name="TKey">
    /// The type used as the student identifier or name.
    /// </typeparam>
    /// <typeparam name="TValue">
    /// The type used for the student's grade.
    /// </typeparam>
    public class StudentGradeRepository<TKey, TValue>
                    where TKey : notnull
    {
        private readonly Dictionary<TKey, TValue> _students = new ();

        /// <summary>
        /// Adds a student and their grade to the repository.
        /// </summary>
        /// <param name="studentName">
        /// The student's identifier or name.
        /// </param>
        /// <param name="grade">
        /// The grade associated with the student.
        /// </param>
        public void Add(TKey studentName, TValue grade)
        {
            this._students[studentName] = grade;
        }

        /// <summary>
        /// Removes a student and their grade record from the repository.
        /// </summary>
        /// <param name="studentName">
        /// The student's identifier or name to remove.
        /// </param>
        public void Remove(TKey studentName)
        {
            this._students.Remove(studentName);
        }

        /// <summary>
        /// Retrieves all student grade records.
        /// </summary>
        /// <returns>
        /// A dictionary containing all students and their corresponding grades.
        /// </returns>
        public IReadOnlyDictionary<TKey, TValue> GetAll()
        {
            return this._students;
        }
    }
}