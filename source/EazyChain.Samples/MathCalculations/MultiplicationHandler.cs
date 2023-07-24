namespace EazyChain.Samples.MathCalculations
{
    internal class MultiplicationHandler : ChainHandler<CalculationsRequest>
    {
        private readonly DumbRepository _repository;

        public MultiplicationHandler(IChainHandler<CalculationsRequest>? handler, DumbRepository repository)
            : base(handler)
        {
            _repository = repository;
        }

        public override CalculationsRequest DoWork(CalculationsRequest request)
        {
            request.Value *= 2;

            return request;
        }
    }
}
