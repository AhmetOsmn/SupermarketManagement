using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TransactionInMemoryRepository : ITransactionRepository
    {
        private List<MyTransaction> transactions;

        public TransactionInMemoryRepository()
        {
            transactions = new List<MyTransaction>();
        }

        public IEnumerable<MyTransaction> Get(string cashierName)
        {
            if(string.IsNullOrWhiteSpace(cashierName))
                return transactions;
            else
                return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<MyTransaction> GetByDate(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(x => x.TimeStamp.Date == date.Date);

            else
                return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase) && x.TimeStamp.Date == date.Date);
        }

        public void Save(string cashierName, int productID, string productName, double price, int beforeQuantity, int soldQuantity)
        {
            int transactionID = 0;
            if(transactions != null && transactions.Count > 0)
            {
                int maxTransactionID = transactions.Max(x => x.TransactionID);
                transactionID = maxTransactionID + 1;
            }
            else
            {
                transactionID = 1;
            }

            transactions.Add(new MyTransaction
            {
                TransactionID = transactionID,
                ProductID = productID,
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQuantity = beforeQuantity,
                SoldQuantity = soldQuantity,
                CashierName = cashierName
            });
        }

        public IEnumerable<MyTransaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);

            else
                return transactions.Where(x => 
                                            string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase) &&
                                            x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
        }
    }
}
