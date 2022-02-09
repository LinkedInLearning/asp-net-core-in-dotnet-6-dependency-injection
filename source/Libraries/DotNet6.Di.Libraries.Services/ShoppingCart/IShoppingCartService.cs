using DotNet6.Di.Libraries.Services.Product.Models;
using DotNet6.Di.Libraries.Services.ShoppingCart.Models;

namespace DotNet6.Di.Libraries.Services.ShoppingCart
{
    /// <summary>
    /// Used for shopping cart methods.
    /// </summary>
    public interface IShoppingCartService
    {
        /// <summary>
        /// Gets the current shopping cart.
        /// </summary>
        /// <returns>The shopping cart as a <see cref="ShoppingCartModel"/> type.</returns>
        /// <exception cref="Exception">Returns an exception if the shopping cart cannot be found.</exception>
        ShoppingCartModel Get();

        /// <summary>
        /// Adds a product to the current shopping cart.
        /// </summary>
        /// <param name="product">An instance of the product</param>
        /// <param name="quantity">The quantity they wish to add.</param>
        void AddProduct(ProductModel product, int quantity);

        /// <summary>
        /// Gets the number of items added to the current shopping cart.
        /// </summary>
        /// <returns>The total number of items.</returns>
        int Count();

        /// <summary>
        /// Has a product been added to the shopping cart?
        /// </summary>
        /// <param name="sku">The unique identifier of the product.</param>
        /// <returns>A <see cref="bool"/> type which determines whether the product has been added to the shopping cart.</returns>
        public bool HasProduct(string sku);

        /// <summary>
        /// Sets the unique id of the shopping cart and adds it to the storage.
        /// </summary>
        /// <param name="id">Unique id of the shopping cart.</param>
        void SetId(Guid id);
    }
}
