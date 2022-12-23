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

        var assemblies = GetAllAssemblies();

        // Add MediatR.
        services.AddMediatR(assemblies);

        // Add MediatR service.
        services.AddTransient<ICommandBus, CommandBus>();

        // Add repositories
        services.AddTransient<IProductRepository, ProductRepository>();

        // Add the App to run.
        services.AddTransient<App>();
        return services;
    }

    private static Assembly[] GetAllAssemblies()
    {
        // Get the currently executing assembly
        var executingAssembly = Assembly.GetExecutingAssembly();

        // Get all the assemblies in the solution
        var referencedAssemblies = executingAssembly.GetReferencedAssemblies();

        // Create a list to store the assemblies
        return referencedAssemblies
            .Select(Assembly.Load)
            .ToArray();
    }
}
