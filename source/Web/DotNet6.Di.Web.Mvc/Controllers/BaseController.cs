using DotNet6.Di.Libraries.Services.ShoppingCart;
using DotNet6.Di.Libraries.Services.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNet6.Di.Web.Mvc.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// The name of the shopping cart id cookie.
        /// </summary>
        const string SHOPPING_CART_ID_COOKIE_NAME = "shoppingCartId";

        /// <summary>
        /// Always ensures we have a shopping cart record set in our storage service.
        /// </summary>
        /// <param name="filterContext">A <see cref="ActionExecutedContext"/> type.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {            
            var storageService = filterContext.HttpContext.RequestServices.GetRequiredService<IStorageService>();
            var shoppingCartService = filterContext.HttpContext.RequestServices.GetRequiredService<IShoppingCartService>();

            var shoppingCartIdCookie = Request.Cookies[SHOPPING_CART_ID_COOKIE_NAME];
            var hasShoppingCartCookie = Guid.TryParse(shoppingCartIdCookie, out var shoppingCartId);

            if (!hasShoppingCartCookie)
            {
                // Set shopping cart id if it does not exist.
                shoppingCartId = Guid.NewGuid();
            }

            // Update cookie.
            filterContext.HttpContext.Response.Cookies.Append(SHOPPING_CART_ID_COOKIE_NAME, shoppingCartId.ToString(), new CookieOptions
            {
                Path = "/",
                Expires = DateTimeOffset.UtcNow.AddMinutes(10)
            });

            // Add a new shopping cart record to the storage service.
            storageService.AddShoppingCart(shoppingCartId);
            shoppingCartService.SetId(shoppingCartId);

            base.OnActionExecuting(filterContext);
        }
    }
}
