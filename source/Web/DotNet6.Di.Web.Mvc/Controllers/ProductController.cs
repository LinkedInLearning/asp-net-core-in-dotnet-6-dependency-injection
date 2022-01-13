using DotNet6.Di.Libraries.Services.Product;
using DotNet6.Di.Libraries.Services.Product.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6.Di.Web.Mvc.Controllers
{
    [Route("product")]
    public class ProductController : BaseController
    {   
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
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
    }
}
