using DotNet6.Di.Libraries.Services.Product.Models;

namespace DotNet6.Di.Libraries.Services.Product
{
    /// <summary>
    /// Used for product methods.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets a product.
        /// </summary>
        /// <param name="sku">The unique sku reference.</param>
        /// <returns>A <see cref="ProductModel"/> type.</returns>
        ProductModel Get(string sku);
    }
}
