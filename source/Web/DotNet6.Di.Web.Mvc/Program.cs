using DotNet6.Di.Libraries.Services.Product;
using DotNet6.Di.Libraries.Services.ShoppingCart;
using DotNet6.Di.Libraries.Services.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add dependency injection.
builder.Services.AddSingleton<IStorageService, StorageService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>(
    (IServiceProvider serviceProvider) =>
    {
        return new ShoppingCartService(serviceProvider.GetRequiredService<IStorageService>());
    }
    );
builder.Services.AddTransient<IProductService, ProductService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
