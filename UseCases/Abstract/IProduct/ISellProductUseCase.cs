namespace UseCases.UseCaseInterfaces.IProduct
{
    public interface ISellProductUseCase
    {
        void Execute(string cashierName, int productID, int quantityToSell);
    }
}