using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VendingMachine.App.Mediator;
using VendingMachine.Application.Mediator;
using VendingMachine.Application.Persistence;
using VendingMachine.Infrastructure.Persistence;

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
