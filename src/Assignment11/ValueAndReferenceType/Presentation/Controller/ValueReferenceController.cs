using ValueReferenceType.Application.Services;

namespace ValueReferenceType.Presentation.Controller
{
    /// <summary>
    /// Handles user interaction for demonstrating the behavior of
    /// value types, reference types, stack memory, and heap memory.
    /// </summary>
    public class ValueReferenceController
    {
        private ValueReferenceDemoService _service;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ValueReferenceController"/> class.
        /// </summary>
        /// <param name="service">
        /// The service that provides value type and reference type demonstrations.
        /// </param>
        public ValueReferenceController(ValueReferenceDemoService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Starts the value type and reference type demonstration workflow.
        /// </summary>
        public void Start()
        {
            int valueTypeVariable;
            int[] referenceTypeArray = { 10 };

            Console.WriteLine("Enter an integer value for value type variable");
            if (!int.TryParse(Console.ReadLine(), out valueTypeVariable))
            {
                Console.WriteLine("Enter integer value");
            }

            Console.WriteLine("Enter am integer value for reference type variable");
            if (!int.TryParse(Console.ReadLine(), out referenceTypeArray[0]))
            {
                Console.WriteLine("Enter integer value");
            }

            Console.WriteLine("Enter new integer value");
            if (!int.TryParse(Console.ReadLine(), out int newValue))
            {
                Console.WriteLine("Enter integer value");
            }

            Console.WriteLine("Old value of value type variable: " + valueTypeVariable);
            Console.WriteLine("Old value of reference type variable: " + referenceTypeArray[0]);

            this._service.ChangeValue(valueTypeVariable, referenceTypeArray, newValue);

            Console.WriteLine("Value type variable Value after function call: " + valueTypeVariable);
            Console.WriteLine("Reference type variable value after function call: " + referenceTypeArray[0]);

            Console.WriteLine("Executing task 2");
            Console.WriteLine("Enter a large number for size of the array");

            if (!int.TryParse(Console.ReadLine(), out int size))
            {
                Console.WriteLine("Enter integer value");
            }

            this._service.CreateLargeArray(size);
            this._service.PerformLargeCalculation();
        }
    }
}