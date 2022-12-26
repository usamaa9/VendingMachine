namespace VendingMachine.App;

[ExcludeFromCodeCoverage]
internal class Program
{
  private static async Task Main()
  {
    var services = ConfigureServices();
    var serviceProvider = services.BuildServiceProvider();

    SeedVendingMachine(serviceProvider);

    var app = serviceProvider.GetService<ConsoleApp.App>()!;
    await app.Run();
  }

  private static IServiceCollection ConfigureServices()
  {
    IServiceCollection services = new ServiceCollection();

    // Add Mediator.
    services.AddMediator();

    // Add repositories
    services.AddRepositories();

    // Add the Console printer
    services.AddSingleton<IConsoleWriter, ConsoleWriter>();

    // Add the user input helper
    services.AddSingleton<IUserInput, UserInput>();


    // Add the App to run.
    services.AddTransient<ConsoleApp.App>();
    return services;
  }

  private static void SeedVendingMachine(IServiceProvider sp)
  {
    var productStore = sp.GetService<IProductStore>()!;

    productStore.AddProduct(new VendingMachineProduct { Name = "Tea", Price = 1.30m, Portions = 10 });
    productStore.AddProduct(new VendingMachineProduct { Name = "Espresso", Price = 1.80m, Portions = 20 });
    productStore.AddProduct(new VendingMachineProduct { Name = "Juice", Price = 1.80m, Portions = 20 });
    productStore.AddProduct(new VendingMachineProduct { Name = "Chicken Soup", Price = 1.80m, Portions = 15 });

    var machineWallet = sp.GetService<IMachineWallet>()!;

    machineWallet.AddCoins(CoinType.TenCent, 100);
    machineWallet.AddCoins(CoinType.TwentyCent, 100);
    machineWallet.AddCoins(CoinType.FiftyCent, 100);
    machineWallet.AddCoins(CoinType.OneEuro, 100);
  }
}