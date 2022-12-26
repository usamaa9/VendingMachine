using VendingMachine.Application.Features.Commands.ReturnCoins;

namespace VendingMachine.App.ConsoleApp;

public partial class App
{
  public async Task ReturnCoins()
  {
    var returnCoinsCommand = new ReturnCoinsCommand();
    await _commandBus.SendAsync<ReturnCoinsCommand, Unit>(returnCoinsCommand);
  }
}