using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.InMemory;
using Plugins.DataStore.SQL;
using Plugins.DataStore.SQL.Repositories;
using UseCases;
using UseCases.Abstract.ITransaction;
using UseCases.Concrete.Transaction;
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
// todo: <select> icerisindeki @bind komutu arastirilacak.
// todo: StateHasChanged arastirilacak.
// todo: public EventCallback<Product> OnProductSelected { get; set; } yapisi arastirilacak.
// todo: InvokeAsync() arastirilacak.

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<MarketContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

//// In Memory icin Dependency Injection.
//builder.Services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();
//builder.Services.AddScoped<IProductRepository, ProductInMemoryRepository>();
//builder.Services.AddScoped<ITransactionRepository, TransactionInMemoryRepository>();

// EF icin DIs
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();



// Use Cases ve Repository'ler icin Dependency Injection.
builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IGetCategoryByIDUseCase, GetCategoryByIDUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();

builder.Services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddTransient<IGetProductByIDUseCase, GetProductByIDUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IViewProductsByCategoryID, ViewProductsByCategoryID>();
builder.Services.AddTransient<ISellProductUseCase, SellProductUseCase>();

builder.Services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>();
builder.Services.AddTransient<IGetTodayTransactionUseCase, GetTodayTransactionUseCase>();
builder.Services.AddTransient<IGetTransactionsUseCase, GetTransactionsUseCase>();



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
