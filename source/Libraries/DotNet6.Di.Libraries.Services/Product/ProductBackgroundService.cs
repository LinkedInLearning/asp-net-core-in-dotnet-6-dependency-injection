using DotNet6.Di.Libraries.Services.Product.Models;
using DotNet6.Di.Libraries.Services.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DotNet6.Di.Libraries.Services.Product
{
    /// <summary>
    /// Used for product background service.
    /// </summary>
    public class ProductBackgroundService : IHostedService
    {
        /// <summary>
        /// A private reference of the service provider that the DI container gives us.
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// A private reference to the storage service from the DI container.
        /// </summary>
        private readonly IStorageService _storageService;

        /// <summary>
        /// A private reference to the logger from the DI container.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Constructs a product background service.
        /// </summary>
        /// <param name="serviceProvier">A reference of the service provider that the DI container gives us.</param>
        /// <param name="storageService">A reference to the storage service from the DI container.</param>
        /// <param name="logger">A reference to the logger from the DI container.</param>
        public ProductBackgroundService(IServiceProvider serviceProvier, IStorageService storageService, ILogger<ProductBackgroundService> logger)
        {
            _serviceProvider = serviceProvier;
            _storageService = storageService;
            _logger = logger;
        }

        /// <summary>
        /// Kicks off a background task that updates the stock.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> type.</param>
        /// <returns>A <see cref="Task"/> type.</returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(async() =>
            {
                // Delay 5 seconds so we can start the app.
                await Task.Delay(new TimeSpan(0, 0, 5));

                // Run the task in the background so the web app can start.
                while (!cancellationToken.IsCancellationRequested)
                {
                    // Create a new scope in the service provider.
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        // Get the product service from the scope.
                        var productService = scope.ServiceProvider.GetService<IProductService>();
                        
                        // New HTTP Client. Get the stock from the API call.
                        var httpClient = new HttpClient();
                        var httpResponse = await httpClient.GetAsync("https://localhost:8001/api/product/stock");

                        if (httpResponse.IsSuccessStatusCode)
                        {
                            // Successful API response, so go ahead and update the stock.
                            _logger.LogInformation("Product stocks received.");

                            // Bind the stock to a list of ProductStockModel.
                            var productStocks = JsonConvert.DeserializeObject<IList<ProductStockModel>>(await httpResponse.Content.ReadAsStringAsync());

                            foreach (var productStock in productStocks)
                            {
                                // Check we can find the product.
                                var product = productService.Get(productStock.Sku);

                                if (product != null)
                                {
                                    // Update the stock and log the information.
                                    product.UpdateStock(productStock.Stock);
                                    _logger.LogInformation("Product stock '{0}' updated to '{1}'.", productStock.Sku, productStock.Stock);
                                }
                            }
                        }
                        else
                        {
                            // Invalid response from the API call.
                            _logger.LogWarning("Not a valid response from the HTTP client. Unable to get stocks.");
                        }
                    }

                    // Makes the task sleep for one minute before restarting the task.
                    await Task.Delay(new TimeSpan(0, 1, 0));
                }
            });

            // Starts the web app.
            return Task.CompletedTask;
        }

        /// <summary>
        /// Runs when the hosted service stops.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> type.</param>
        /// <returns>A <see cref="Task"/> type.</returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
