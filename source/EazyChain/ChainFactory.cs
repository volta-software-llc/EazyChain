using System;
using System.Collections.Generic;
using System.Linq;
using EazyChain.Registration;
using Microsoft.Extensions.DependencyInjection;

namespace EazyChain
{
    public class ChainFactory<T> : IChainFactory<T>
        where T : IChainRequest
    {
        private readonly IServiceProvider _serviceProvider;
        private IList<Type> _registrations;

        public ChainFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IChainHandler<T> CreateChain()
        {
            var profile = _serviceProvider.GetService<ChainProfile<T>>();

            if (profile == null)
            {
                throw new NullReferenceException("No profile's were found for the provided request.");
            }

            if (!profile.ChainRegistrations.Any())
            {
                throw new ArgumentNullException(nameof(profile.ChainRegistrations), "The profile does not have any steps registered.");
            }

            _registrations = profile.ChainRegistrations.Reverse().ToList();

            var builtChain = InstantiateHandlers(null, 0);

            return builtChain.Handler;
        }

        private (IChainHandler<T>? Handler, int Index) InstantiateHandlers(IChainHandler<T>? handler, int index)
        {
            if (index == _registrations.Count)
            {
                return (handler, index);
            }

            if (handler == null)
            {
                var handlerType = _registrations.First().GetConstructors().FirstOrDefault(x => x.IsPublic);

                if (handlerType != null)
                {
                    var dependencies = new List<object?>();

                    foreach (var dependency in handlerType.GetParameters())
                    {
                        if (dependency.ParameterType == typeof(IChainHandler<T>))
                        {
                            dependencies.Add(null);
                        }
                        else
                        {
                            dependencies.Add(_serviceProvider.GetService(dependency.ParameterType));
                        }
                    }

                    var step = handlerType.Invoke(dependencies.ToArray()) as IChainHandler<T>;

                    return InstantiateHandlers(step, ++index);
                }
            }
            else
            {
                var handlerType = _registrations[index].GetConstructors().FirstOrDefault(x => x.IsPublic);

                if (handlerType != null)
                {
                    var dependencies = new List<object?>();

                    foreach (var dependency in handlerType.GetParameters())
                    {
                        if (dependency.ParameterType == typeof(IChainHandler<T>))
                        {
                            dependencies.Add(handler);
                        }
                        else
                        {
                            dependencies.Add(_serviceProvider.GetService(dependency.ParameterType));
                        }
                    }

                    var step = handlerType.Invoke(dependencies.ToArray()) as IChainHandler<T>;

                    return InstantiateHandlers(step, ++index);
                }

            }
            return InstantiateHandlers(handler, ++index);
        }
    }
}
