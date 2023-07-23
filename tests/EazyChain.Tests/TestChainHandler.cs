using System;

namespace EazyChain.Tests
{
    internal class TestChainHandler : ChainHandler<TestRequest>
    {
        public TestChainHandler(IChainHandler<TestRequest>? handler)
            : base(handler)
        {
        }

        public override TestRequest DoWork(TestRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
