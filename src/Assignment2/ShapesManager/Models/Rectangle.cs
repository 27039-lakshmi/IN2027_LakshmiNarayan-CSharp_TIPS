namespace ShapesManager.Models
{
    internal class Rectangle : Shape
    {
        public Rectangle(string color, int length, int breadth)
        {
            this.Color = color;
            this.Length = length;
            this.Breadth = breadth;
        }
        public int Length { get; set; }
        public int Breadth { get; set; }



        public override double CalculateArea()
        {
            return this.Length * this.Breadth;
        }

        public override void PrintDetails()
        {
            Console.WriteLine($"Color of your Rectangle is {Color} \nArea of your shape is {CalculateArea()}");
        }
    }
}