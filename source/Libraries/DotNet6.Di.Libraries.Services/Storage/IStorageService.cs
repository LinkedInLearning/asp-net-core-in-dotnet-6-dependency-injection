using DotNet6.Di.Libraries.Services.Product.Models;

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
    }
}
