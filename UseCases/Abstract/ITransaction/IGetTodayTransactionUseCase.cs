using CoreBusiness;

namespace UseCases
{
    public interface IGetTodayTransactionUseCase
    {
        IEnumerable<MyTransaction> Execute(string cashierName);
    }
}