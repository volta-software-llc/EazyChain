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

            services.AddSingleton<ChainProfile<CalculationsRequest>, MyChainProfile>();
            services.AddTransient(typeof(IChainFactory<>), typeof(ChainFactory<>));
            services.AddTransient<DumbRepository>();

            //services.AddEazyChain(Assembly.GetExecutingAssembly());

            var provider = services.BuildServiceProvider();

            var factory = provider.GetRequiredService<IChainFactory<CalculationsRequest>>();

            var chain = factory.CreateChain();

            Console.WriteLine(chain.Handle(new CalculationsRequest
            {
                Value = 10,
            }).Value);
        }
    }
}