using CoreBusiness;

namespace UseCases.UseCaseInterfaces.ICategory
{
    public interface IViewCategoriesUseCase
    {
        IEnumerable<Category> Execute();
    }
}