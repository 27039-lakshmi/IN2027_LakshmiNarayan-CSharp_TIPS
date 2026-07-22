using ShapesManager.Models;

namespace ShapesManager.Services
{
    /// <summary>
    /// Provides services for creating shapes, validating user input,
    /// and displaying shape details.
    /// </summary>
    internal static class ShapeService
    {
        /// <summary>
        /// Displays the details of the specified shape.
        /// </summary>
        /// <param name="shape">
        /// The shape whose details are to be displayed.
        /// </param>
        public static void PrintDetails(Shape shape)
        {
            shape.PrintDetails();
        }

        /// <summary>
        /// Validates whether the provided input is a valid integer value.
        /// </summary>
        /// <param name="circleRadius">
        /// The input value to validate.
        /// </param>
        /// <returns>
        /// <c>true</c> if the input is a valid integer; otherwise, <c>false</c>.
        /// </returns>
        public static bool ValidateInput(string circleRadius)
        {
            if (int.TryParse(circleRadius, out int _))
            {
                if (int.Parse(circleRadius) < 0)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Creates a rectangle using the provided color, length, and breadth,
        /// then displays its details.
        /// </summary>
        /// <param name="rectangleColor">
        /// The color of the rectangle.
        /// </param>
        /// <param name="lengthOfRectangle">
        /// The length of the rectangle as a string.
        /// </param>
        /// <param name="breadthOfRectangle">
        /// The breadth of the rectangle as a string.
        /// </param>
        public static void CreateRectangle(
            string rectangleColor,
            string lengthOfRectangle,
            string breadthOfRectangle)
        {
            var rectangle = new Rectangle(
                rectangleColor,
                int.Parse(lengthOfRectangle),
                int.Parse(breadthOfRectangle));

            PrintDetails(rectangle);
        }

        /// <summary>
        /// Creates a circle using the provided color and radius,
        /// then displays its details.
        /// </summary>
        /// <param name="circleColor">
        /// The color of the circle.
        /// </param>
        /// <param name="radiusOfCircle">
        /// The radius of the circle as a string.
        /// </param>
        public static void CreateCircle(string circleColor, string radiusOfCircle)
        {
            var circle = new Circle(circleColor, int.Parse(radiusOfCircle));
            PrintDetails(circle);
        }

        /// <summary>
        /// Validates whether the provided color contains only alphabetic characters.
        /// </summary>
        /// <param name="color">
        /// The color value to validate.
        /// </param>
        /// <returns>
        /// <c>true</c> if the color is valid; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsColorValid(string color)
        {
            foreach (var c in color)
            {
                if (char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}