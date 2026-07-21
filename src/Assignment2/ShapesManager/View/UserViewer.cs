using ShapesManager.Models;
using ShapesManager.Services;

namespace ShapesManager.View
{
    internal class UserViewer
    {
        public static void Start()
        {
            var service = new ShapeService();
            string? userChoice;
            do
            {
                Console.WriteLine("Choose your shape \n" +
                    "[1] Rectangle \n[2] Circle\n[3] Exit");
                userChoice = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userChoice))
                {
                    userChoice = "0";
                }
                if (int.TryParse(userChoice, out int _))
                {
                    switch (userChoice)
                    {
                        case "1":
                            string rectangleColor = GetColorInput("rectangle");
                            Console.WriteLine("Enter length of the Rectangle");
                            string? lengthOfRectangle = Console.ReadLine();
                            Console.WriteLine("Enter width of the Rectangle");
                            string? breadthOfRectangle = Console.ReadLine();
                            if (service.ValidateInput(lengthOfRectangle) && service.ValidateInput(breadthOfRectangle))
                            {
                                service.CreateRectangle(rectangleColor, lengthOfRectangle, breadthOfRectangle);
                            }
                            else
                            {
                                Console.WriteLine("Length and Breadth should be an integer");
                            }

                            break;
                        case "2":
                            string circleColor = GetColorInput("circle");
                            Console.WriteLine("Enter radius of the Circle");
                            string? radiusOfCircle = Console.ReadLine();
                            if (service.ValidateInput(radiusOfCircle))
                            {
                                service.CreateCircle(circleColor, radiusOfCircle);
                            }
                            else
                            {
                                Console.WriteLine("Radius should be an integer");
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
            }
            while (userChoice != "3");
        }

        public static string GetColorInput(string shape)
        {
            Console.WriteLine($"Enter color of {shape}");
            return Console.ReadLine()!;
        }
    }
}
