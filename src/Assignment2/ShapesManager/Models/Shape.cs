namespace ShapesManager.Models
{
    internal abstract class Shape
    {
        protected string? Color { get; set; }
        public abstract double CalculateArea();
        public abstract void PrintDetails();
    }
}