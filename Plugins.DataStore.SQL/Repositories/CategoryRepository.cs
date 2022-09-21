using CoreBusiness;
using System.Collections.Generic;
using System.Linq;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MarketContext context;

        public CategoryRepository(MarketContext context)
        {
            this.context = context;
        }

        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void DeleteCategory(int categoryID)
        {
            var category = context.Categories.Find(categoryID);

            if (category == null) return;

            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        public Category GetCategoryByID(int categoryID)
        {
            return context.Categories.Find(categoryID);
        }

        public void UpdateCategory(Category category)
        {
            var selectedCategory = context.Categories.Find(category.CategoryID);
            selectedCategory.Name = category.Name;
            selectedCategory.Description = category.Description;
            context.SaveChanges();
        }
    }
}
