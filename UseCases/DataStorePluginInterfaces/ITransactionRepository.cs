using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<MyTransaction> Get(string cashierName);
        IEnumerable<MyTransaction> GetByDate(string cashierName, DateTime date);
        IEnumerable<MyTransaction> Search(string cashierName, DateTime startDate, DateTime endDate);
        void Save(string cashierName, int productID,string productName, double price, int berforeQuantity, int soldQuantity);
    }
}
