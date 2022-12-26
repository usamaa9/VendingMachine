using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Features.Queries.GetDepositedAmount;

namespace VendingMachine.App;

public partial class App
{
  public async Task ShowDepositedAmount()
  {
    var result =
      await _commandBus.SendAsync<GetDepositedAmountQuery, Dictionary<CoinType, int>>(new GetDepositedAmountQuery());

    _consolePrinter.PrintCoinsInWallet(result.Value!);
  }
}