using System.Reflection;
using EazyChain.Registration;
using EazyChain.Samples.MathCalculations;
using Microsoft.Extensions.DependencyInjection;

namespace EazyChain.Samples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddEazyChain(Assembly.GetExecutingAssembly());

            var provider = services.BuildServiceProvider();

            var factory = provider.GetRequiredService<IChainFactory<CalculationsRequest>>();

            Console.WriteLine(factory.CreateChain().Handle(new CalculationsRequest
            {
                Value = 10,
            }).Value);
        }
    }
}