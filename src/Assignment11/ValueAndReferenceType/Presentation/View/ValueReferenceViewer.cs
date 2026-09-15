using ValueReferenceType.Application.Services;

namespace ValueReferenceType.Presentation.View
{
    /// <summary>
    /// Handles user interaction for demonstrating the behavior of
    /// value types, reference types, stack memory, and heap memory.
    /// </summary>
    public class ValueReferenceViewer
    {
        private ValueReferenceDemoService _service;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ValueReferenceViewer"/> class.
        /// </summary>
        /// <param name="service">
        /// The service that provides value type and reference type demonstrations.
        /// </param>
        public ValueReferenceViewer(ValueReferenceDemoService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Starts the value type and reference type demonstration workflow.
        /// </summary>
        public void Start()
        {
            this.HandleValueType();
            this.HandleReferenceType();
            this.HandleLargeArray();
        }

        /// <summary>
        /// Demonstrates large array allocation and processing.
        /// </summary>
        private void HandleLargeArray()
        {
            Console.WriteLine("Executing task 2");
            Console.WriteLine("Enter a large number for size of the array");

            if (!int.TryParse(Console.ReadLine(), out int size))
            {
                Console.WriteLine("Enter integer value");
                return;
            }

            Console.WriteLine("Creating large array");
            this._service.CreateLargeArray(size);
            Console.WriteLine("Permorming large calculation");
            this._service.PerformLargeCalculation();
        }

        private void HandleValueType()
        {
            Console.WriteLine("Enter an integer value for value type variable");
            int valueTypeVariable = this.GetIntegerInput(out bool isValid);
            Console.WriteLine("Enter new integer value");
            int newValue = this.GetIntegerInput(out isValid);

            Console.WriteLine("Old value of value type variable: " + valueTypeVariable);
            this._service.ChangeValueType(valueTypeVariable, newValue);

            Console.WriteLine("Value type variable Value after function call: " + valueTypeVariable);
        }

        private void HandleReferenceType()
        {
            int[] referenceTypeArray = new int[1];
            Console.WriteLine("Enter an integer value for reference type variable");
            referenceTypeArray[0] = this.GetIntegerInput(out bool isValid);

            Console.WriteLine("Enter new integer value");
            int newValue = this.GetIntegerInput(out isValid);

            Console.WriteLine("Old value of reference type variable: " + referenceTypeArray[0]);
            this._service.ChangeReferenceType(referenceTypeArray, newValue);
            Console.WriteLine("Reference type variable value after function call: " + referenceTypeArray[0]);
        }

        private int GetIntegerInput(out bool isValid)
        {
            int userInput;
            if (!int.TryParse(Console.ReadLine(), out userInput))
              {
                Console.WriteLine("Enter valid integer");
                isValid = false;
                return -1;
              }

            isValid = true;
            return userInput;
        }
    }
}