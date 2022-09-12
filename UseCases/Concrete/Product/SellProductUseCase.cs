using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces.IProduct;

namespace UseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IRecordTransactionUseCase recordTransactionUseCase;

        public SellProductUseCase(IProductRepository productRepository, IRecordTransactionUseCase recordTransactionUseCase)
        {
            this.productRepository = productRepository;
            this.recordTransactionUseCase = recordTransactionUseCase;
        }
        public void Execute(string cashierName, int productID, int quantityToSell)
        {
            var product = productRepository.GetProductById(productID);
            if (product == null) return;

            recordTransactionUseCase.Execute(cashierName, productID, quantityToSell);

            product.Quantity -= quantityToSell;
            productRepository.UpdateProduct(product);
        }
    }
}
