using CoreBusiness;

namespace UseCases.UseCaseInterfaces.IProduct
{
    public interface IViewProductsUseCase
    {
        IEnumerable<Product> Execute();
    }
}