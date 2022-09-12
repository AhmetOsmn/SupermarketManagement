namespace UseCases
{
    public interface IRecordTransactionUseCase
    {
        void Execute(string cashierName, int productID, int quantity);
    }
}