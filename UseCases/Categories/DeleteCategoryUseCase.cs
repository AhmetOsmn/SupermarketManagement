using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;
using UseCases.UseCaseInterfaces.ICategory;

namespace UseCases
{
    public class DeleteCategoryUseCase : IDeleteCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public DeleteCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void Execute(int categoryID)
        {
            categoryRepository.DeleteCategory(categoryID);
        }
    }
}
