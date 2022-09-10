using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces.ICategory;

namespace UseCases
{
    public class GetCategoryByIDUseCase : IGetCategoryByIDUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public GetCategoryByIDUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Category Execute(int categoryID)
        {
            return categoryRepository.GetCategoryByID(categoryID);
        }
    }
}
