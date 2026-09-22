namespace LinqExploration.Domain.Models;

/// <summary>
/// Represents a summary of products grouped by category.
/// </summary>
public class CategorySummaryDTO
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CategorySummaryDTO"/> class.
    /// </summary>
    /// <param name="category">
    /// The product category being summarized (for example, Electronics or Books).
    /// </param>
    /// <param name="count">
    /// The total number of products belonging to the category.
    /// </param>
    /// <param name="expensiveProduct">
    /// The product with the highest price in the category.
    /// </param>
    public CategorySummaryDTO(
        string category,
        int count,
        string expensiveProduct)
    {
        this.Category = category;
        this.Count = count;
        this.ExpensiveProduct = expensiveProduct;
    }

    /// <summary>
    /// Gets or sets category of the product
    /// </summary>
    /// <value>
    /// Name of the category for which the summary is generated.
    /// </value>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets count of the product
    /// </summary>
    /// /// <value>
    /// count of the number of products in each category.
    /// </value>
    public int Count { get; set; }

    /// <summary>
    /// Gets or sets the expensive product.
    /// </summary>
    /// <value>
    /// Most expensive product in each category.
    /// </value>
    public string ExpensiveProduct { get; set; }
}