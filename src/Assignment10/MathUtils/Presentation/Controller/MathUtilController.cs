using Calculator.Application.Service;
using Calculator.Domain.Enums;

namespace Calculator.Presentation.Controller
{
    /// <summary>
    /// Handles user interaction and coordinates calculator operations.
    /// </summary>
    public class MathUtilController
    {
        private readonly MathUtils _mathutils;

        /// <summary>
        /// Initializes a new instance of the <see cref="MathUtilController"/> class.
        /// </summary>
        /// <param name="mathutil">
        /// Provides arithmetic operation functionalities.
        /// </param>
        public MathUtilController(MathUtils mathutil)
        {
            this._mathutils = mathutil;
        }

        /// <summary>
        /// Starts the calculator application and processes user-selected operations.
        /// Displays the available operations, accepts user input, validates operands,
        /// and invokes the corresponding arithmetic operation.
        /// </summary>
        public void Start()
        {
            int userChoice;
            CalculatorOperation operation;
            do
            {
                Console.WriteLine("Enter operation\n" +
                                  "[1] Addition\n" +
                                  "[2] Subtraction\n" +
                                  "[3] Multiplication\n" +
                                  "[4] Division\n" +
                                  "[5] Exit");

                if (!int.TryParse(Console.ReadLine(), out userChoice))
                {
                    Console.WriteLine("Choice should be an integer");
                    operation = CalculatorOperation.Invalid;
                    continue;
                }

                operation = (CalculatorOperation)userChoice;
                this.HandleMenu(operation);
            }
            while (operation != CalculatorOperation.Exit);
        }

        public void HandleMenu(CalculatorOperation operation)
        {
            switch (operation)
            {
                case CalculatorOperation.Add:
                    if (!this.TryGetOperands(out int number1, out int number2))
                    {
                        return;
                    }

                    int sum = this._mathutils.PerformAddition(number1, number2);
                    Console.WriteLine("Sum " + sum);
                    break;

                case CalculatorOperation.Subtract:
                    if (!this.TryGetOperands(out number1, out number2))
                    {
                        return;
                    }

                    int difference = this._mathutils.PerformSubtraction(number1, number2);
                    Console.WriteLine("Difference " + difference);
                    break;

                case CalculatorOperation.Multiplication:
                    if (!this.TryGetOperands(out number1, out number2))
                    {
                        return;
                    }

                    int product = this._mathutils.PerformMultiplication(number1, number2);
                    Console.WriteLine("Product " + product);
                    break;

                case CalculatorOperation.Division:
                    if (!this.TryGetOperands(out number1, out number2))
                    {
                        return;
                    }

                    try
                    {
                        double quotient = this._mathutils.PerformDivision(number1, number2);
                        Console.WriteLine("Quotient " + quotient);
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("Divisor should not be zero");
                    }

                    break;

                case CalculatorOperation.Exit:
                    Console.WriteLine("Exiting");
                    break;

                default:
                    Console.WriteLine("Choices should be between 1 and 5");
                    break;
            }
        }

        /// <summary>
        /// Tries to get operands.
        /// </summary>
        /// <param name="operand1">stores operand1 value </param>
        /// <param name="operand2">stores operand2 value</param>
        /// <returns>true if operands are valid, otherwise false</returns>
        public bool TryGetOperands(out int operand1, out int operand2)
        {
            var result = this.GetOperands();
            if (!result.IsValid)
            {
                operand1 = 0;
                operand2 = 0;
                return false;
            }

            operand1 = result.Operand1;
            operand2 = result.Operand2;
            return true;
        }

        /// <summary>
        /// Retrieves two valid integer operands from the user.
        /// </summary>
        /// <returns>
        /// A tuple containing:
        /// <list type="bullet">
        /// <item><description>IsValid - Indicates whether both operands were entered successfully.</description></item>
        /// <item><description>Operand1 - The first operand.</description></item>
        /// <item><description>Operand2 - The second operand.</description></item>
        /// </list>
        /// </returns>
        public (bool IsValid, int Operand1, int Operand2) GetOperands()
        {
            int operand1 = this.GetIntegerInput(out bool isOperand1Valid);
            if (!isOperand1Valid)
            {
                return (false, 0, 0);
            }

            int operand2 = this.GetIntegerInput(out bool isOperand2Valid);
            if (!isOperand2Valid)
            {
                return (false, 0, 0);
            }

            return (true, operand1, operand2);
        }

        /// <summary>
        /// Prompts the user to enter an integer value.
        /// Allows a maximum of three attempts before marking the input as invalid.
        /// </summary>
        /// <param name="isValid">
        /// Set to <c>true</c> when a valid integer is entered; otherwise <c>false</c>.
        /// </param>
        /// <returns>
        /// The integer entered by the user if valid; otherwise <see cref="int.MinValue"/>.
        /// </returns>
        public int GetIntegerInput(out bool isValid)
        {
            int maxNumberOfTries = 3;
            for (int numberOfTries = 1; numberOfTries <= maxNumberOfTries; numberOfTries++)
            {
                Console.WriteLine("Enter integer");

                if (int.TryParse(Console.ReadLine(), out int integerInput))
                {
                    isValid = true;
                    return integerInput;
                }

                Console.WriteLine("It should be a valid integer");
            }

            Console.WriteLine("Maximum number of tries reached");
            isValid = false;
            return int.MinValue;
        }
    }
}