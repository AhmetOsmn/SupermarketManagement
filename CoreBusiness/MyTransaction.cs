namespace CoreBusiness
{
    public class MyTransaction
    {
        public int TransactionID { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int BeforeQuantity { get; set; }
        public int SoldQuantity { get; set; }
        public string CashierName { get; set; }
    }
}
