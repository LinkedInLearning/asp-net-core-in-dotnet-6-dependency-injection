using DotNet6.Di.Libraries.Services.Product.Models;
using DotNet6.Di.Libraries.Services.Storage;

namespace DotNet6.Di.Libraries.Services.Product
{
    /// <summary>
    /// Used for product methods.
    /// </summary>
    public class ProductService : IProductService, IDisposable
    {
        /// <summary>
        /// A private reference to the storage service from the DI container.
        /// </summary>
        private readonly IStorageService _storageService;

        /// <summary>
        /// Constructs a product service.
        /// </summary>
        /// <param name="storageService">A reference to the storage service from the DI container.</param>
        public ProductService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        /// <summary>
        /// Gets a product.
        /// </summary>
        /// <param name="sku">The unique sku reference.</param>
        /// <returns>A <see cref="ProductModel"/> type.</returns>
        public ProductModel Get(string sku)
        {
            return _storageService.Products.FirstOrDefault(p => p.Sku == sku);
        }

        /// <summary>
        /// Called when the shopping cart service is disposed of.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        void IDisposable.Dispose()
        {
            // Dispose objects in here.
        }
    }
}
