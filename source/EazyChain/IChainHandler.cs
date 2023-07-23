namespace EazyChain
{
    public interface IChainHandler<T>
        where T : IChainRequest
    {
        T Handle(T request);
    }
}
