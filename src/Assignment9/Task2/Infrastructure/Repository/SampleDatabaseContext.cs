using Task2.Domain.Models;

namespace Task2.Infrastructure.Repository
{
    public class SampleDatabaseContext
    {
        public List<Product> Products { get; set; }

        public SampleDatabaseContext()
        {
            Products = new List<Product>();
        }

        public List<Product> GetAllProducts()
        {
            return Products.ToList();
        }
        public void AddProducts(List<Product> products)
        {

            Products.AddRange(products);
        }
    }
}
