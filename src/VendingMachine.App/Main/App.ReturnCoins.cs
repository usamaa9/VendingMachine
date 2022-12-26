using VendingMachine.Application.Features.Commands.ReturnCoins;

namespace VendingMachine.ConsoleApp.Main;

public partial class App
{
  public async Task ReturnCoins()
  {
    var returnCoinsCommand = new ReturnCoinsCommand();
    await _commandBus.SendAsync<ReturnCoinsCommand, Unit>(returnCoinsCommand);
  }
}