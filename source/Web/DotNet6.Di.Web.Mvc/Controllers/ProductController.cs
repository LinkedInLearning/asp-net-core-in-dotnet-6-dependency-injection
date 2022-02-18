using DotNet6.Di.Libraries.Services.Product;
using DotNet6.Di.Libraries.Services.Product.Models;
using DotNet6.Di.Libraries.Services.ShoppingCart;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6.Di.Web.Mvc.Controllers
{
    [Route("product")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IShoppingCartService _shoppingCartService;

        public ProductController(IProductService productService, IShoppingCartService shoppingCartService)
        {
            _productService = productService;
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet("{sku}")]
        public IActionResult Get(string sku)
        {
            var product = _productService.Get(sku);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost("{sku}")]
        public IActionResult AddToShoppingCart(string sku)
        {
            var product = _productService.Get(sku);

            if (product == null)
            {
                return NotFound();
            }

            _shoppingCartService.AddProduct(product, 1);

            return RedirectToAction("Get", new { sku });
        }

    }
}
