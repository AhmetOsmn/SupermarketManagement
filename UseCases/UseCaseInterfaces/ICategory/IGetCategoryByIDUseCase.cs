using CoreBusiness;

namespace UseCases.UseCaseInterfaces.ICategory;

public interface IGetCategoryByIDUseCase
{
    Category Execute(int categoryID);
}
