namespace UseCases.UseCaseInterfaces.IProduct
{
    public interface ISellProductUseCase
    {
        void Execute(int productID, int quantityToSell);
    }
}