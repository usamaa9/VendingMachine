using VendingMachine.Application.Features.Queries.ShowDepositedAmount;

namespace VendingMachine.App.ConsoleApp;

public partial class App
{
  public async Task ShowDepositedAmount()
  {
    await _commandBus.SendAsync<ShowDepositedAmountQuery, Unit>(new ShowDepositedAmountQuery());
  }
}