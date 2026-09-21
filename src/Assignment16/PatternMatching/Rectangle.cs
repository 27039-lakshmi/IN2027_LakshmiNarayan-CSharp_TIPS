namespace PatternMatching
{
    /// <summary>
    /// Represents a rectangle shape and provides
    /// functionality to calculate its area.
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="color">The color of the rectangle.</param>
        /// <param name="shape">The name of the shape.</param>
        /// <param name="length">The length of the rectangle.</param>
        /// <param name="breadth">The breadth of the rectangle.</param>
        public Rectangle(string color, string shape, int length, int breadth)
            : base(color, shape)
        {
            this.Length = length;
            this.Breadth = breadth;
        }

        /// <summary>
        /// Gets or sets the length of the rectangle.
        /// </summary>
        /// <value>Length of the rectangle</value>
        public int Length { get; set; }

        /// <summary>
        /// Gets or sets the breadth of the rectangle.
        /// </summary>
        /// <value>Breadth of the rectangle</value>
        public int Breadth { get; set; }

        /// <summary>
        /// Calculates the area of the rectangle.
        /// </summary>
        /// <returns>The area of the rectangle.</returns>
        public int CalculateArea()
        {
            return this.Length * this.Breadth;
        }
    }
}