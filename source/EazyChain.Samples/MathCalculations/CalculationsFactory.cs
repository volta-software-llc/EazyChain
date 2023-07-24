namespace EazyChain.Samples.MathCalculations
{
    public class CalculationsFactory : IChainFactory<CalculationsRequest>
    {
        public IChainHandler<CalculationsRequest> CreateChain()
        {
            var second = new MultiplicationHandler(null, new DumbRepository());
            var first = new AdditionHandler(second);

            return first;
        }
    }
}
