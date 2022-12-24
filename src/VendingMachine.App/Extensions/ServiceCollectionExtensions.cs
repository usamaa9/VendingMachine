using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using VendingMachine.App.Mediator;
using VendingMachine.Application.Mediator;
using VendingMachine.Application.Persistence;
using VendingMachine.Infrastructure.Persistence;

namespace VendingMachine.App.Extensions;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
  /// <summary>
  /// Add all the repositories.
  /// </summary>
  /// <param name="services"></param>
  /// <returns></returns>
  public static IServiceCollection AddRepositories(
    this IServiceCollection services)
  {
    services.AddSingleton<IProductRepository, ProductRepository>();
    services.AddSingleton<IUserWalletRepository, UserWalletRepository>();

    return services;
  }

  /// <summary>
  /// Add the mediator services.
  /// </summary>
  /// <param name="services"></param>
  /// <returns></returns>
  public static IServiceCollection AddMediator(this IServiceCollection services)
  {
    var assemblies = GetAllAssemblies();

    services.AddMediatR(assemblies)
      .AddTransient<ICommandBus, CommandBus>();
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