using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces.IProduct;

namespace UseCases.Products
{
    public class ViewProductsUseCase : IViewProductsUseCase
    {
        private readonly IProductRepository productRepository;

        public ViewProductsUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> Execute()
        {
            return productRepository.GetProducts();
        }
    }
}
