using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MarketContext context;

        public TransactionRepository(MarketContext context)
        {
            this.context = context;
        }
        public IEnumerable<MyTransaction> Get(string cashierName)
        {
            return context.MyTransactions.Where(x => x.CashierName == cashierName).ToList();
        }

        public IEnumerable<MyTransaction> GetByDate(string cashierName, DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return context.MyTransactions.Where(x => x.TimeStamp.Date == date.Date);

            else
                return context.MyTransactions.Where(x => x.CashierName.ToLower() == cashierName.ToLower() && x.TimeStamp.Date == date.Date);

        }

        public void Save(string cashierName, int productID, string productName, double price, int berforeQuantity, int soldQuantity)
        {
            var transaction = new MyTransaction
            {
                ProductID = productID,
                ProductName = productName,
                TimeStamp = DateTime.Now,
                Price = price,
                BeforeQuantity = berforeQuantity,
                SoldQuantity = soldQuantity,
                CashierName = cashierName,
            };

            context.MyTransactions.Add(transaction);
            context.SaveChanges();
        }

        public IEnumerable<MyTransaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return context.MyTransactions.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);

            else
                return context.MyTransactions.Where(x =>
                                            x.CashierName.ToLower() == cashierName.ToLower() &&
                                            x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
        }
    }
}
