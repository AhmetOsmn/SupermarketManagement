using CoreBusiness;

namespace UseCases.UseCaseInterfaces.IProduct
{
    public interface IGetProductByIDUseCase
    {
        Product Execute(int productID);
    }
}