using MediatR;
using VendingMachine.Application.Features.Queries.GetDepositedAmount;

namespace VendingMachine.App;

public partial class App
{
  public async Task ShowDepositedAmount()
  {
    await _commandBus.SendAsync<ShowDepositedAmountQuery, Unit>(new ShowDepositedAmountQuery());
  }
}