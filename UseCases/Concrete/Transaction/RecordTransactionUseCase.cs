using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces.IProduct;

namespace UseCases
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IGetProductByIDUseCase getProductByIDUseCase;

        public RecordTransactionUseCase(
            ITransactionRepository transactionRepository,
            IGetProductByIDUseCase getProductByIDUseCase
        )
        {
            this.transactionRepository = transactionRepository;
            this.getProductByIDUseCase = getProductByIDUseCase;
        }

        public void Execute(string cashierName, int productID, int quantity)
        {
            var product = getProductByIDUseCase.Execute(productID);
            transactionRepository.Save(cashierName, productID, product.Name, product.Price.Value, product.Quantity.Value, quantity);
        }
    }
}
