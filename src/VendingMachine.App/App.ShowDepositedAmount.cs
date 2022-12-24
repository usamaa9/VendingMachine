using MediatR;
using VendingMachine.Application.Features.Queries.ShowDepositedAmount;

namespace VendingMachine.App;

public partial class App
{
  public async Task ShowDepositedAmount()
  {
    var query = new ShowDepositedAmountQuery();

    await _commandBus.SendAsync<ShowDepositedAmountQuery, Unit>(query);
  }
}