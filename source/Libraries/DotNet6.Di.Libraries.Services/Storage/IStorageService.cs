using DotNet6.Di.Libraries.Services.Product.Models;
using DotNet6.Di.Libraries.Services.ShoppingCart.Models;

namespace DotNet6.Di.Libraries.Services.Storage
{
    /// <summary>
    /// Stores the data used for the application.
    /// </summary>
    public interface IStorageService
    {
        /// <summary>
        /// Stores a list of products.
        /// </summary>
        IList<ProductModel> Products { get;  }

        /// <summary>
        /// Stores a list of shopping carts.
        /// </summary>
        IList<ShoppingCartModel> ShoppingCarts { get;}

        /// <summary>
        /// Adds a shopping cart to the storage.
        /// </summary>
        /// <param name="id">The unique id of the shopping cart.</param>
        void AddShoppingCart(Guid id);
    }
}
