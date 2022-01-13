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
            AddProduct(new ProductModel("BUB-APR", "A Gumball for Your Thoughts Apron", 24, 4));
            AddProduct(new ProductModel("BUB-BAS", "A Gumball for Your Thoughts Baseball Hat", 29, 2));
            AddProduct(new ProductModel("BUB-MUG", "A Gumball for Your Thoughts Mug", 16, 6));
            AddProduct(new ProductModel("BUB-TSH", "A Gumball for Your Thoughts T-shirt", 26, 10));
        }

        /// <summary>
        /// Adds a product to the storage.
        /// </summary>
        /// <param name="productModel">The <see cref="ProductModel"/> type to be added.</param>
        private void AddProduct(ProductModel productModel)
        {
            if (!Products.Any(p => p.Sku == productModel.Sku))
            {
                Products.Add(productModel);
            }
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
