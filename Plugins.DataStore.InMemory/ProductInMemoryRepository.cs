﻿using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductInMemoryRepository : IProductRepository
    {
        private List<Product> products;

        public ProductInMemoryRepository()
        {
            products = new List<Product>()
            {
                new Product{ ProductID=1, CategoryID = 1, Name="Ice Tea", Quantity = 100, Price=1.99},
                new Product{ ProductID=2, CategoryID = 1, Name="Canada Dry", Quantity = 200, Price=1.99},
                new Product{ ProductID=3, CategoryID = 2, Name="Whole Wheat Bread", Quantity = 300, Price=1.50},
                new Product{ ProductID=4, CategoryID = 2, Name="White Bread", Quantity = 300, Price=1.50},
            };
        }

        public void AddProduct(Product product)
        {
            if (products.Any(c => c.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;

            if (products != null && products.Count > 0)
            {
                int maxID = products.Max(c => c.ProductID);
                product.ProductID = maxID + 1;
            }
            else
            {
                product.ProductID = 1;
            }

            products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }
    }
}