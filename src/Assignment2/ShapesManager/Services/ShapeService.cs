using ShapesManager.Models;

namespace ShapesManager.Services
{
    internal class ShapeService
    {
        public void PrintDetails(Shape shape)
        {
            shape.PrintDetails();
        }

        public bool ValidateInput(string circleRadius)
        {
            return int.TryParse(circleRadius, out int _);
        }

        public void CreateRectangle(string rectangleColor, string lengthOfRectangle, string breadthOfRectangle)
        {
            var rectangle = new Rectangle(rectangleColor, int.Parse(lengthOfRectangle), int.Parse(breadthOfRectangle));
            this.PrintDetails(rectangle);
        }

        public void CreateCircle(string circleColor, string radiusOfCircle)
        {
            var circle = new Circle(circleColor, int.Parse(radiusOfCircle));
            this.PrintDetails(circle);
        }
    }
}