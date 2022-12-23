using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VendingMachine.Mediator;

namespace VendingMachine;

internal class Program
{
    private static void Main()
    {
        var services = ConfigureServices();
        var serviceProvider = services.BuildServiceProvider();

        serviceProvider.GetService<App>()!.Run();
    }

    private static IServiceCollection ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        // Add MediatR.
        services.AddMediatR(Assembly.GetExecutingAssembly());

        // Add MediatR service.
        services.AddTransient<ICommandBus, CommandBus>();

        // Add the App to run.
        services.AddTransient<App>();
        return services;
    }
}
