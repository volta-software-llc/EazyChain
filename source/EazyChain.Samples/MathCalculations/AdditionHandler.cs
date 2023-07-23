namespace EazyChain.Samples.MathCalculations
{
    public class AdditionHandler : ChainHandler<CalculationsRequest>
    {
        public AdditionHandler(IChainHandler<CalculationsRequest>? handler)
            : base(handler)
        {
        }

        public override CalculationsRequest DoWork(CalculationsRequest request)
        {
            ++request.Value;

            return request;
        }
    }
}
