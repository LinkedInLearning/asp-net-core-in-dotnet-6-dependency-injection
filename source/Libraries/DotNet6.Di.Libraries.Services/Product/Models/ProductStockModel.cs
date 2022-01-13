using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet6.Di.Libraries.Services.Product.Models
{
    /// <summary>
    /// Stores a product's stock.
    /// </summary>
    public class ProductStockModel
    {
        /// <summary>
        /// Unique identifier of the product.
        /// </summary>
        public string Sku { get; }

        /// <summary>
        /// The stock quantity.
        /// </summary>
        public int Stock { get; }

        /// <summary>
        /// Constructs a new product stock.
        /// </summary>
        /// <param name="sku">Unique identifier of the product.</param>
        /// <param name="stock">The stock quantity.</param>
        public ProductStockModel(string sku, int stock)
        {
            Sku = sku;
            Stock = stock;
        }
     }
}
