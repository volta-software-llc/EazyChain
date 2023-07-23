namespace EazyChain
{
    public abstract class ChainRequest : IChainRequest
    {
        public bool IsFaulted { get; private set; }

        public Exception? Exception { get; private set; }

        public virtual void Faulted()
        {
            IsFaulted = true;
        }

        public virtual void Faulted(Exception exception)
        {
            IsFaulted = true;
            Exception = exception;
        }
    }
}
