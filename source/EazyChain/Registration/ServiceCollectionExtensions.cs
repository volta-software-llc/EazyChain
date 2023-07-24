using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EazyChain.Registration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEazyChain(this IServiceCollection services, params Assembly[] assemblies)
        {
            foreach (Assembly assembly in assemblies)
            {
                TryAddChainFactories(services, assembly);
            }

            return services;
        }

        private static void TryAddChainFactories(IServiceCollection service, Assembly assembly)
        {
            assembly.GetTypes()
                .Where(type => !type.IsAbstract && !type.IsInterface)
                .ToList()
                .ForEach(implementationType =>
                {
                    var chainFactory = implementationType.GetInterfaces().FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IChainFactory<>));

                    if (chainFactory != null)
                    {
                        service.TryAddTransient(chainFactory, implementationType);
                    }
                });
        }
    }
}
