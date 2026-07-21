namespace ShapesManager.Models
{
    internal class Circle : Shape
    {
        public Circle(string color, int radius)
        {
            this.Color = color;
            this.Radius = radius;
        }
        public int Radius { get; set; }

        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public override void PrintDetails()
        {
            Console.WriteLine($"Color of your Circle is {Color} \nArea of your shape is {CalculateArea()}");
        }
    }
}
