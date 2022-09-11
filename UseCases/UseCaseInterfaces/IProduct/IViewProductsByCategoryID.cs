using CoreBusiness;

namespace UseCases.UseCaseInterfaces.IProduct
{
    public interface IViewProductsByCategoryID
    {
        IEnumerable<Product> Execute(int categoryID);
    }
}