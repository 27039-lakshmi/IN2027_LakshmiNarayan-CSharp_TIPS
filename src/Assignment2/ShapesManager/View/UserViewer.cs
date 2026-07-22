using ShapesManager.Models;
using ShapesManager.Services;

namespace ShapesManager.View
{
    /// <summary>
    /// Handles all user interactions for creating and managing shapes.
    /// Presents menu options, receives user input, validates input,
    /// and invokes the appropriate shape creation methods.
    /// </summary>
    internal class UserViewer
    {
        /// <summary>
        /// Starts the application and displays the shape selection menu.
        /// Continues running until the user chooses to exit.
        /// </summary>
        public static void Start()
        {
            var service = new ShapeService();
            string? userChoice;

            do
            {
                Console.WriteLine(
                    "Choose your shape \n" +
                    "[1] Rectangle \n" +
                    "[2] Circle\n" +
                    "[3] Exit");

                userChoice = Console.ReadLine();

                // Handle null, empty, or whitespace input.
                if (string.IsNullOrWhiteSpace(userChoice))
                {
                    userChoice = "0";
                }

                // Validate that the menu choice is numeric.
                if (int.TryParse(userChoice, out int _))
                {
                    switch (userChoice)
                    {
                        case "1":
                            string rectangleColor = GetColorInput("rectangle");

                            if (rectangleColor == string.Empty)
                            {
                                Console.WriteLine("Invalid color name");
                            }
                            else
                            {
                                Console.WriteLine("Enter length of the Rectangle");
                                string? lengthOfRectangle = Console.ReadLine() ?? string.Empty;

                                Console.WriteLine("Enter width of the Rectangle");
                                string? breadthOfRectangle = Console.ReadLine() ?? string.Empty;

                                if (service.ValidateInput(lengthOfRectangle) &&
                                    service.ValidateInput(breadthOfRectangle))
                                {
                                    service.CreateRectangle(
                                        rectangleColor,
                                        lengthOfRectangle,
                                        breadthOfRectangle);
                                }
                                else
                                {
                                    Console.WriteLine("Length and Breadth should be an integer");
                                }
                            }

                            break;

                        case "2":
                            string circleColor = GetColorInput("circle");

                            if (circleColor == string.Empty)
                            {
                                Console.WriteLine("Invalid color name");
                            }
                            else
                            {
                                Console.WriteLine("Enter radius of the Circle");
                                string radiusOfCircle = Console.ReadLine() ?? "0";

                                if (service.ValidateInput(radiusOfCircle))
                                {
                                    service.CreateCircle(circleColor, radiusOfCircle);
                                }
                                else
                                {
                                    Console.WriteLine("Radius should be an integer");
                                }
                            }

                            break;

                        case "3":
                            Console.WriteLine("Exitting ...");
                            break;

                        default:
                            Console.WriteLine("Enter 1 or 2 or 3");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Choice should be integer");
                }
            }
            while (userChoice != "3");
        }

        /// <summary>
        /// Prompts the user to enter a color for the specified shape
        /// and validates the entered color.
        /// </summary>
        /// <param name="shape">
        /// The name of the shape for which the color is being requested.
        /// </param>
        /// <returns>
        /// The validated color name if valid; otherwise, an empty string.
        /// </returns>
        public static string GetColorInput(string shape)
        {
            var service = new ShapeService();

            Console.WriteLine($"Enter color of {shape}");
            string shapeColor = Console.ReadLine() ?? string.Empty;

            if (service.IsColorValid(shapeColor))
            {
                return shapeColor;
            }

            return string.Empty;
        }
    }
}