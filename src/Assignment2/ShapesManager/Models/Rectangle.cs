namespace ShapesManager.Models
{
    /// <summary>
    /// Represents a rectangle shape.
    /// Contains properties and methods specific to a rectangle,
    /// including area calculation and detail display.
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="color">The color of the rectangle.</param>
        /// <param name="length">The length of the rectangle.</param>
        /// <param name="breadth">The breadth of the rectangle.</param>
        public Rectangle(string color, int length, int breadth)
        {
            this.Color = color;
            this.Length = length;
            this.Breadth = breadth;
        }

        /// <summary>
        /// Gets or sets the length of the rectangle.
        /// </summary>
        /// <value>
        /// An integer value representing the length of the rectangle.
        /// </value>
        public int Length { get; set; }

        /// <summary>
        /// Gets or sets the breadth of the rectangle.
        /// </summary>
        /// <value>
        /// An integer value representing the breadth of the rectangle.
        /// </value>
        public int Breadth { get; set; }

        /// <summary>
        /// Calculates the area of the rectangle.
        /// </summary>
        /// <returns>
        /// The area of the rectangle as a double value.
        /// </returns>
        public override double CalculateArea()
        {
            return this.Length * this.Breadth;
        }

        /// <summary>
        /// Displays the rectangle's details, including
        /// its color and calculated area.
        /// </summary>
        public override void PrintDetails()
        {
            Console.WriteLine(
                $"Color of your Rectangle is {this.Color} \n" +
                $"Area of your shape is {this.CalculateArea()}");
        }
    }
}