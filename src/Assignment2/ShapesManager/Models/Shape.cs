namespace ShapesManager.Models
{
    /// <summary>
    /// Represents the base class for all shapes.
    /// Defines common properties and methods that must be
    /// implemented by all derived shape classes.
    /// </summary>
    internal abstract class Shape
    {
        /// <summary>
        /// Gets or sets the color of the shape.
        /// </summary>
        /// <value>
        /// A string representing the color of the shape.
        /// </value>
        protected string? Color { get; set; }

        /// <summary>
        /// Calculates the area of the shape.
        /// Each derived shape must provide its own area calculation logic.
        /// </summary>
        /// <returns>
        /// The calculated area of the shape.
        /// </returns>
        public abstract double CalculateArea();

        /// <summary>
        /// Displays the details of the shape.
        /// Each derived shape must provide its own implementation.
        /// </summary>
        public abstract void PrintDetails();
    }
}