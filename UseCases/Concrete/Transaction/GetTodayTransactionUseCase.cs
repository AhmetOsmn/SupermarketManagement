using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class GetTodayTransactionUseCase : IGetTodayTransactionUseCase
    {
        private readonly ITransactionRepository transactionRepository;

        public GetTodayTransactionUseCase(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public IEnumerable<MyTransaction> Execute(string cashierName)
        {
            return transactionRepository.GetByDate(cashierName, DateTime.Now);
        }
    }
}
