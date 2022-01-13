using DotNet6.Di.Libraries.Services.Product.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6.Di.Web.Mvc.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ApiProductController : ControllerBase
    {
        /// <summary>
        /// Gets the product stock.
        /// </summary>
        /// <returns>Returns all the product stock quantities.</returns>
        [HttpGet("stock")]
        public IList<ProductStockModel> GetStock()
        {
            var productStock = new List<ProductStockModel>();

            productStock.Add(new ProductStockModel("BUB-APR", 10));
            productStock.Add(new ProductStockModel("BUB-BAS", 14));
            productStock.Add(new ProductStockModel("BUB-MUG", 17));
            productStock.Add(new ProductStockModel("BUB-TSH", 24));

            return productStock;
        }
    }
}
