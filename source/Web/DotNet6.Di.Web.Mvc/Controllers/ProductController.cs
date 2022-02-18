using DotNet6.Di.Libraries.Services.Product.Models;
using Microsoft.AspNetCore.Mvc;
using DotNet6.Di.Libraries.Services.Product;

namespace DotNet6.Di.Web.Mvc.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{sku}")]
        public IActionResult Get(string sku)
        {
            return View(_productService.Get(sku));
        }
    }
}
