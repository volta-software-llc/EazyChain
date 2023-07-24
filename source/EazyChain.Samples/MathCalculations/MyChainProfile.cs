using EazyChain.Registration;

namespace EazyChain.Samples.MathCalculations
{
    public class MyChainProfile : ChainProfile<CalculationsRequest>
    {
        public MyChainProfile()
        {
            AddStep<AdditionHandler>()
                .AddStep<MultiplicationHandler>();
        }
    }
}
