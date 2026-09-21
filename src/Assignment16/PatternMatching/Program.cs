using PatternMatching;

namespace Assignments
{
    /// <summary>
    /// Demonstrates pattern matching in C# by identifying
    /// derived shape types and displaying their details.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point.
        /// Creates a collection of shapes and displays
        /// their details using pattern matching.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                var shapes = new List<Shape>()
            {
                new Rectangle("Red", "Rectangle", 5, 10),
                new Triangle("Blue", "Triangle", 3, 8),
                new Circle("Yellow", "Circle", 7),
            };

                foreach (var shape in shapes)
                {
                    DisplayShapeDetails(shape);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Displays details of a shape based on its runtime type
        /// using pattern matching in a switch statement.
        /// </summary>
        /// <param name="shape">
        /// The shape whose details are to be displayed.
        /// </param>
        public static void DisplayShapeDetails(Shape shape)
        {
            switch (shape)
            {
                case Rectangle rectangle:
                    Console.WriteLine($"Shape {rectangle.ShapeName} Length {rectangle.Length} Breadth {rectangle.Breadth} Area {rectangle.CalculateArea()}");
                    break;

                case Triangle triangle:
                    Console.WriteLine($"Shape {triangle.ShapeName} Base {triangle.Base} Height {triangle.Height} Area {triangle.CalculateArea()}");
                    break;

                case Circle circle:
                    Console.WriteLine($"Shape {circle.ShapeName} Radius {circle.Radius} Area {circle.CalculateArea()}");
                    break;

                default:
                    Console.WriteLine("Unknown object");
                    break;
            }
        }
    }
}