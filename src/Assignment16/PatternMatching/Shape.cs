namespace PatternMatching
{
    /// <summary>
    /// Represents the base class for all shapes.
    /// Contains common properties shared by derived shape types.
    /// </summary>
    public class Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        /// <param name="color">The color of the shape.</param>
        /// <param name="shape">The name of the shape.</param>
        public Shape(string color, string shape)
        {
            this.ShapeColor = color;
            this.ShapeName = shape;
        }

        /// <summary>
        /// Gets or sets the color of the shape.
        /// </summary>
        /// <value>Color of the shape</value>
        public string ShapeColor { get; set; }

        /// <summary>
        /// Gets or sets the name of the shape.
        /// </summary>
        /// <value>Name of the shape</value>
        public string ShapeName { get; set; }
    }
}