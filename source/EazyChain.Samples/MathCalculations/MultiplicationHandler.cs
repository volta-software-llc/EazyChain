namespace EazyChain.Samples.MathCalculations
{
    internal class MultiplicationHandler : ChainHandler<CalculationsRequest>
    {
        public MultiplicationHandler(IChainHandler<CalculationsRequest>? handler)
            : base(handler)
        {
        }

        public override CalculationsRequest DoWork(CalculationsRequest request)
        {
            request.Value *= 2;

            return request;
        }
    }
}
