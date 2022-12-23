using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VendingMachine.Mediator;
using VendingMachine.Persistence;
using VendingMachine.Persistence.Implementations;

namespace VendingMachine;

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

        // Add MediatR.
        services.AddMediatR(Assembly.GetExecutingAssembly());

        // Add MediatR service.
        services.AddTransient<ICommandBus, CommandBus>();

        // Add repositories
        services.AddTransient<IProductRepository, ProductRepository>();

        // Add the App to run.
        services.AddTransient<App>();
        return services;
    }
}
