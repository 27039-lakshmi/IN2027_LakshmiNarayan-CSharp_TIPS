using Task4.Application;

namespace Task4.Presentation
{
    /// <summary>
    /// Provides a console-based user interface for managing
    /// and displaying student grade records.
    /// </summary>
    public class StudentGradeConsole
    {
        private StudentGradeService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentGradeConsole"/> class.
        /// </summary>
        /// <param name="service">
        /// Service responsible for student grade management operations.
        /// </param>
        public StudentGradeConsole(StudentGradeService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Starts the student grade management demonstration.
        /// Adds sample students and grades, displays the records,
        /// removes a student, and displays the updated records.
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Adding students : ");

            this._service.AddStudent("Lakshmi Narayan", 10);
            this._service.AddStudent("Dinesh", 12);
            this._service.AddStudent("Harini", 8);
            this._service.AddStudent("Kani", 1);
            this._service.AddStudent("Tarrun", 5);

            this.DisplayStudents();
            Console.WriteLine("Removing Kani from students");

            this._service.RemoveStudent("Kani");
            this.DisplayStudents();
        }

        /// <summary>
        /// Retrieves and displays all student grade records.
        /// </summary>
        public void DisplayStudents()
        {
            var students = this._service.GetStudents();

            foreach (var student in students)
            {
                Console.WriteLine($"Student Name : {student.Key}\n" +
                                  $"Student Grade : {student.Value}");
            }
        }
    }
}