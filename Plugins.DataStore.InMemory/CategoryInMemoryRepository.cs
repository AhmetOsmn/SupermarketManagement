using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> categories;

        public CategoryInMemoryRepository()
        {
            categories = new List<Category>()
            {
                new Category() { CategoryID = 1, Name = "Beverage", Description="Beverage"},
                new Category() { CategoryID = 2, Name = "Bakery", Description="Bakery"},
                new Category() { CategoryID = 3, Name = "Meat", Description="Meat"},
                new Category() { CategoryID = 4, Name = "Dessert", Description="Dessert"}
            };
        }
        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }

        public void AddCategory(Category category)
        {
            if (categories.Any(c => c.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;
            
            if(categories != null && categories.Count > 0)
            {
                int maxID = categories.Max(c => c.CategoryID);
                category.CategoryID = maxID + 1;
            }
            else
            {
                category.CategoryID = 1;
            }
   
            categories.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryByID(category.CategoryID);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.CategoryID = category.CategoryID;
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;    
            }
        }

        public Category GetCategoryByID(int categoryID)
        {
            return categories?.FirstOrDefault(x => x.CategoryID == categoryID);
        }

        public void DeleteCategory(int categoryID)
        {
            categories?.Remove(GetCategoryByID(categoryID));    
        }
    }
}