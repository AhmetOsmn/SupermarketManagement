using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces.IProduct;

namespace UseCases
{
    public class ViewProductsByCategoryID : IViewProductsByCategoryID
    {
        private readonly IProductRepository productRepository;

        public ViewProductsByCategoryID(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> Execute(int categoryID)
        {
            return productRepository.GetProductsByCategoryID(categoryID);
        }
    }
}
