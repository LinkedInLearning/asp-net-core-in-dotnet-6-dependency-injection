using DotNet6.Di.Libraries.Services.Product.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet6.Di.Web.Mvc.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
       

        [HttpGet("{sku}")]
        public IActionResult Get(string sku)
        {
            return View();
        }
    }
}
