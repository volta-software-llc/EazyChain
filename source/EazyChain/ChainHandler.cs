namespace EazyChain
{
    public abstract class ChainHandler<TRequest> : IChainHandler<TRequest>
        where TRequest : IChainRequest
    {
        private readonly IChainHandler<TRequest>? _handler;

        protected ChainHandler(IChainHandler<TRequest>? handler)
        {
            _handler = handler;
        }

        public virtual TRequest Handle(TRequest request)
        {
            if (request.IsFaulted)
            {
                return request;
            }

            var result = Middleware(request);

            return _handler == null ? result : _handler.Handle(request);
        }

        public abstract TRequest DoWork(TRequest request);

        public virtual TRequest Middleware(TRequest request)
        {
            return DoWork(request);
        }
    }
}
