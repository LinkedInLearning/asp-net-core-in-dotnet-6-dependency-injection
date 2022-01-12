using DotNet6.Di.Libraries.Services.Product.Models;
using DotNet6.Di.Libraries.Services.ShoppingCart.Models;

namespace DotNet6.Di.Libraries.Services.Storage
{
    /// <summary>
    /// Stores the data used for the application.
    /// </summary>
    public class StorageService : IStorageService
    {
        /// <summary>
        /// Stores a list of products.
        /// </summary>
        public IList<ProductModel> Products { get; private set; }

        /// <summary>
        /// Stores a list of shopping carts.
        /// </summary>
        public IList<ShoppingCartModel> ShoppingCarts { get; private set; }

        /// <summary>
        ///  Constructs a storage service.
        /// </summary>
        public StorageService()
        {
            Products = new List<ProductModel>();
            ShoppingCarts = new List<ShoppingCartModel>();

            // Store a list of all the products for the online shop.
        }

        /// <summary>
        /// Adds a shopping cart to the storage.
        /// </summary>
        /// <param name="id">The unique id of the shopping cart.</param>
        public void AddShoppingCart(Guid id)
        {
            if (!ShoppingCarts.Any(sc => sc.Id == id))
            {
                ShoppingCarts.Add(new ShoppingCartModel(id));
            }
        }
    }
}
