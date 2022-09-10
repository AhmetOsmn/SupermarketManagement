using Plugins.DataStore.InMemory;
using UseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.Products;
using UseCases.UseCaseInterfaces.ICategory;
using UseCases.UseCaseInterfaces.IProduct;
using WebApp.Data;

// todo: IIS Express arastirilacak.
// todo: @inject arastirilacak.
// todo: services.AddTransient arastirilacak.
// todo: OnInitialized metodu arastirilacak.
// todo: StringComparison.OrdinalIgnoreCase  arastirilacak.
// todo: out int iCategoryID yapisi arastirilacak.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// In Memory icin Dependency Injection.
builder.Services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductInMemoryRepository>();

// Use Cases ve Repository'ler icin Dependency Injection.
builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IGetCategoryByIDUseCase, GetCategoryByIDUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();

builder.Services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
