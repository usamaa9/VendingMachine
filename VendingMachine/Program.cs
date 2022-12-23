using Microsoft.Extensions.DependencyInjection;
using VendingMachine.App.Extensions;

namespace VendingMachine.App;

internal class Program
{
    private static async Task Main()
    {
        var services = ConfigureServices();
        var serviceProvider = services.BuildServiceProvider();

        var app = serviceProvider.GetService<App>()!;
        await app.Run();
    }

    private static IServiceCollection ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        // Add Mediator.
        services.AddMediator();

        // Add repositories
        services.AddRepositories();

        // Add the App to run.
        services.AddTransient<App>();
        return services;
    }
}
