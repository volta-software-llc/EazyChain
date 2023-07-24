using System;
using System.Collections.Generic;

namespace EazyChain.Registration
{
    public class ChainProfile<TRequest>
        where TRequest : IChainRequest
    {
        private readonly List<Type> _registrations;

        public ChainProfile()
        {
            _registrations = new List<Type>();
        }

        public IReadOnlyList<Type> ChainRegistrations => _registrations.AsReadOnly();

        public ChainProfile<TRequest> AddStep<THandler>()
            where THandler : IChainHandler<TRequest>
        {
            _registrations.Add(typeof(THandler));

            return this;
        }
    }
}
