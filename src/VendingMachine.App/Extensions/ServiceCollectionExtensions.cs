namespace VendingMachine.App.Extensions;

/// <summary>
/// Extension methods for <see cref="IServiceCollection"/>.
/// </summary>
[ExcludeFromCodeCoverage]
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
    services.AddSingleton<IProductStore, ProductStore>();
    services.AddSingleton<IUserWallet, UserWallet>();
    services.AddSingleton<IMachineWallet, MachineWallet>();

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