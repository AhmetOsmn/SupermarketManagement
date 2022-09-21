using CoreBusiness;
using UseCases.Abstract.ITransaction;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.Concrete.Transaction
{
    public class GetTransactionsUseCase : IGetTransactionsUseCase
    {
        private readonly ITransactionRepository transactionRepository;

        public GetTransactionsUseCase(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        public IEnumerable<MyTransaction> Execute(string cashierName, DateTime startDate, DateTime endDate)
        {
            return transactionRepository.Search(cashierName, startDate, endDate);
        }

        public IEnumerable<MyTransaction> Execute(string cashierName)
        {
            throw new NotImplementedException();
        }
    }
}
