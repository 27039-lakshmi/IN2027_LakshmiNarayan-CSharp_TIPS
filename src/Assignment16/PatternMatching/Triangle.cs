namespace PatternMatching
{
    /// <summary>
    /// Represents a triangle shape and provides
    /// functionality to calculate its area.
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="color">Color of the shape</param>
        /// <param name="shape">Shape name of the shape</param>
        /// <param name="baseOfTriangle">Base value of the triangle</param>
        /// <param name="heightOfTriangle">Height value of the rectangle</param>
        public Triangle(string color, string shape, int baseOfTriangle, int heightOfTriangle)
            : base(color, shape)
        {
            this.Base = baseOfTriangle;
            this.Height = heightOfTriangle;
        }

        /// <summary>
        /// Gets or sets the base length of the triangle.
        /// </summary>
        /// <value>Base of the triangle</value>
        public int Base { get; set; }

        /// <summary>
        /// Gets or sets the height of the triangle.
        /// </summary>
        /// <value>Height of the triangle</value>
        public int Height { get; set; }

        /// <summary>
        /// Calculates the area of the triangle.
        /// </summary>
        /// <returns>The area of the triangle.</returns>
        public int CalculateArea()
        {
            return this.Base * this.Height;
        }
    }
}