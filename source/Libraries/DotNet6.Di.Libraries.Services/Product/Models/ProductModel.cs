namespace DotNet6.Di.Libraries.Services.Product.Models
{
    /// <summary>
    /// Stores a product.
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Unique identifier of the product.
        /// </summary>
        public string Sku { get; }

        /// <summary>
        /// Name of the product.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Price of the product.
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// The stock quantity.
        /// </summary>
        public int Stock { get; protected set; }

        /// <summary>
        /// Constructs a new product.
        /// </summary>
        /// <param name="sku">Unique identifier of the product.</param>
        /// <param name="name">Name of the product.</param>
        /// <param name="price">Price of the product.</param>
        /// <param name="stock">The product's stock quantity.</param>
        public ProductModel(string sku, string name, decimal price, int stock = 0)
        {
            Sku = sku;
            Name = name;
            Price = price;
            Stock = stock;
        }

        /// <summary>
        /// Updates the stock.
        /// </summary>
        /// <param name="stock">The stock quantity.</param>
        public void UpdateStock(int stock)
        {
            Stock = stock;
        }

    }
}
