using Microsoft.Extensions.DependencyInjection;

namespace VendingMachine;

internal class Program
{
    private static void Main(string[] args)
    {
        var services = ConfigureServices();
        var serviceProvider = services.BuildServiceProvider();

        serviceProvider.GetService<App>()!.Run();
    }

    private static IServiceCollection ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddTransient<App>();
        return services;
    }
}
