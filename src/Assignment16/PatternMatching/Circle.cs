namespace PatternMatching
{
    /// <summary>
    /// Represents a circle shape and provides
    /// functionality to calculate its area.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="color">The color of the circle.</param>
        /// <param name="shape">The name of the shape.</param>
        /// <param name="radius">The radius of the circle.</param>
        public Circle(string color, string shape, int radius)
            : base(color, shape)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Gets or sets the radius of the circle.
        /// </summary>
        /// <value>Radius of the circle</value>
        public int Radius { get; set; }

        /// <summary>
        /// Calculates the area of the circle.
        /// </summary>
        /// <returns>The area of the circle.</returns>
        public double CalculateArea()
        {
            return 3.14 * this.Radius * this.Radius;
        }
    }
}