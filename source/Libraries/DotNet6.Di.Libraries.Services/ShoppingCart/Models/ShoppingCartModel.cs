using DotNet6.Di.Libraries.Services.Product.Models;

namespace DotNet6.Di.Libraries.Services.ShoppingCart.Models
{
    /// <summary>
    /// Stores a shopping cart.
    /// </summary>
    public class ShoppingCartModel
    {
        /// <summary>
        /// Unique id of the shopping cart.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// A list of all the items stored in the shopping cart.
        /// </summary>
        public IList<ShoppingCartItemModel> Items { get; }

        /// <summary>
        /// Constructs a new shopping cart.
        /// </summary>
        /// <param name="id">Unique id of the shopping cart.</param>
        public ShoppingCartModel(Guid id)
        {
            Id = id;
            Items = new List<ShoppingCartItemModel>();
        }

        /// <summary>
        /// Adds or updates an item to the shopping cart.
        /// </summary>
        /// <param name="product">The product being updated.</param>
        /// <param name="quantity">The quantity being updated.</param>
        public void AddUpdateItem(ProductModel product, int quantity)
        {
            var item = Items.FirstOrDefault(item => item.Product == product);

            if (item == null)
            {
                // Item doesn't exist in the shopping cart, so add it.
                Items.Add(new ShoppingCartItemModel(product, quantity));
            }
            else
            {
                // Item exists in the shopping cart, so update the quantity.
                item.UpdateQuantity(product, quantity);
            }
        }
    }
}
