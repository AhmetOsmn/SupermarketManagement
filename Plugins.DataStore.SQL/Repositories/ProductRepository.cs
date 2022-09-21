using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketContext context;

        public ProductRepository(MarketContext context)
        {
            this.context = context;
        }
        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(int productID)
        {
            var product = context.Products.Find(productID);
            if (product == null) return;

            context.Products.Remove(product);
            context.SaveChanges();
        }

        public Product GetProductById(int productID)
        {
            return context.Products.Find(productID);
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public IEnumerable<Product> GetProductsByCategoryID(int categoryID)
        {
            return context.Products.Where(x => x.CategoryID == categoryID).ToList();
        }

        public void UpdateProduct(Product product)
        {
            var selectedProduct = context.Products.Find(product.ProductID);

            selectedProduct.CategoryID = product.CategoryID;
            selectedProduct.Name = product.Name;
            selectedProduct.Price = product.Price;
            selectedProduct.Quantity = product.Quantity;

            context.SaveChanges();
        }
    }
}
