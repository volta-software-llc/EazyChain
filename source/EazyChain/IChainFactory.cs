namespace EazyChain
{
    public interface IChainFactory<T>
        where T : IChainRequest
    {
        IChainHandler<T> CreateChain();
    }
}
