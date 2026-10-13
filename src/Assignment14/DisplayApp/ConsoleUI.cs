namespace DisplayApp
{
    /// <summary>
    /// Provides a console-based user interface for performing
    /// mathematical operations using the Calculator class.
    /// </summary>
    public static class ConsoleUI
    {
        /// <summary>
        /// Starts the calculator application by collecting user input,
        /// validating it, and performing the selected operation.
        /// </summary>
        public static void Start()
        {
            double number1 = GetOperandInput("Enter the first integer:");
            double number2 = GetOperandInput("Enter the second integer:");
            string operation = GetOperationInput("Enter the operation (+, -, *, /):");

            switch (operation)
            {
                case "+":
                    Console.WriteLine($"Result: {MathApp.Calculator.Add(number1, number2)}");
                    break;

                case "-":
                    Console.WriteLine($"Result: {MathApp.Calculator.Subtract(number1, number2)}");
                    break;

                case "*":
                    Console.WriteLine($"Result: {MathApp.Calculator.Multiply(number1, number2)}");
                    break;

                case "/":
                    if (number2 == 0)
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                    }
                    else
                    {
                        Console.WriteLine($"Result: {MathApp.Calculator.Divide(number1, number2)}");
                    }

                    break;

                default:
                    Console.WriteLine("Invalid operation.");
                    break;
            }
        }

        /// <summary>
        /// Application entry point.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        private static void Main(string[] args)
        {
        }

        /// <summary>
        /// Prompts the user to enter a mathematical operator and validates the input.
        /// </summary>
        /// <param name="prompt">The message displayed to the user.</param>
        /// <returns>
        /// A valid operator string such as "+", "-", "*", or "/".
        /// </returns>
        private static string GetOperationInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine() !;

            while (!UtilityApp.Validator.IsValidOperator(input))
            {
                Console.WriteLine("Invalid input. Please enter a valid operator.");
                input = Console.ReadLine() !;
            }

            return input;
        }

        /// <summary>
        /// Prompts the user to enter a numeric operand and validates the input.
        /// </summary>
        /// <param name="prompt">The message displayed to the user.</param>
        /// <returns>
        /// The validated numeric value entered by the user.
        /// </returns>
        private static double GetOperandInput(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine() !;

            while (!UtilityApp.Validator.IsValidNumber(input))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                input = Console.ReadLine() !;
            }

            return double.Parse(input);
        }
    }
}