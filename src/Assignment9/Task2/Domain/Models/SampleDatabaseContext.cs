namespace Task1.Domain.Models
{
    public class SampleDatabaseContext
    {
        public List<Product> Products { get; set; }

        public SampleDatabaseContext()
        {
            this.Products = new List<Product>();
        }
    }
}
