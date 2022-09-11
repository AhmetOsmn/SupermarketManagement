using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces.IProduct;

namespace UseCases.Products
{
    public class GetProductByIDUseCase : IGetProductByIDUseCase
    {
        private readonly IProductRepository productRepository;

        public GetProductByIDUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product Execute(int productID)
        {
            return productRepository.GetProductById(productID);
        }
    }
}
