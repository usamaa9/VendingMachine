using MediatR;
using VendingMachine.Application.Features.ReturnCoins;

namespace VendingMachine.App;

public partial class App
{
  public async Task ReturnCoins()
  {
    var returnCoinsCommand = new ReturnCoinsCommand();
    await _commandBus.SendAsync<ReturnCoinsCommand, Unit>(returnCoinsCommand);
  }
}