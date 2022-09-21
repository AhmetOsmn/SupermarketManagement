using CoreBusiness;

namespace UseCases.Abstract.ITransaction
{
    public interface IGetTransactionsUseCase
    {
        IEnumerable<MyTransaction> Execute(string cashierName);
        IEnumerable<MyTransaction> Execute(string cashierName, DateTime startDate, DateTime endDate);
    }
}