using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces.IProduct;

namespace UseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository productRepository;

        public SellProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Execute(int productID, int quantityToSell)
        {
            var product = productRepository.GetProductById(productID);
            if (product == null) return;

            product.Quantity -= quantityToSell;
            productRepository.UpdateProduct(product);
        }
    }
}
