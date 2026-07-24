namespace ShapesManager.Models
{
    /// <summary>
    /// Represents a circle shape.
    /// Contains properties and methods specific to a circle,
    /// including area calculation and detail display.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="color">The color of the circle.</param>
        /// <param name="radius">The radius of the circle.</param>
        public Circle(string color, int radius)
        {
            this.Color = color;
            this.Radius = radius;
        }

        /// <summary>
        /// Gets or sets the radius of the circle.
        /// </summary>
        /// <value>
        /// An integer value representing the radius of the circle.
        /// </value>
        public int Radius { get; set; }

        /// <summary>
        /// Calculates the area of the circle.
        /// </summary>
        /// <returns>
        /// The area of the circle as a double value.
        /// </returns>
        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        /// <summary>
        /// Displays the circle's details, including
        /// its color and calculated area.
        /// </summary>
        public override void PrintDetails()
        {
            Console.WriteLine(
                $"Color of your Circle is {this.Color} \n" +
                $"Area of your shape is {this.CalculateArea()}");
        }
    }
}