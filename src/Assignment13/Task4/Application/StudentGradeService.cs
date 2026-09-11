using Task4.Infrastructure;

namespace Task4.Application
{
    /// <summary>
    /// Provides business logic for managing student grades.
    /// Acts as an intermediary between the presentation layer
    /// and the student grade repository.
    /// </summary>
    public class StudentGradeService
    {
        private StudentGradeRepository<string, int> _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentGradeService"/> class.
        /// </summary>
        /// <param name="repo">
        /// Repository used to store and manage student grade records.
        /// </param>
        public StudentGradeService(StudentGradeRepository<string, int> repo)
        {
            this._repo = repo;
        }

        /// <summary>
        /// Adds a student and their grade to the repository.
        /// </summary>
        /// <param name="studentName">
        /// The name of the student.
        /// </param>
        /// <param name="grade">
        /// The grade assigned to the student.
        /// </param>
        public void AddStudent(string studentName, int grade)
        {
            this._repo.Add(studentName, grade);
        }

        /// <summary>
        /// Removes a student and their grade record from the repository.
        /// </summary>
        /// <param name="studentName">
        /// The name of the student to remove.
        /// </param>
        public void RemoveStudent(string studentName)
        {
            this._repo.Remove(studentName);
        }

        /// <summary>
        /// Retrieves all student grade records.
        /// </summary>
        /// <returns>
        /// A dictionary containing student names as keys
        /// and their corresponding grades as values.
        /// </returns>
        public Dictionary<string, int> GetStudents()
        {
            return this._repo.GetAll();
        }
    }
}