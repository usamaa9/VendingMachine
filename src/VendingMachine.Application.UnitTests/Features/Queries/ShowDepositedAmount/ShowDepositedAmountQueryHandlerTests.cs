using VendingMachine.Application.Features.Queries.ShowDepositedAmount;

namespace VendingMachine.Application.UnitTests.Features.Queries.ShowDepositedAmount;

public class ShowDepositedAmountQueryHandlerTests
{
  private readonly Mock<IConsoleWriter> _consolePrinter;
  private readonly ShowDepositedAmountQueryHandler _handler;
  private readonly Mock<IUserWallet> _userWallet;
  private readonly ShowDepositedAmountQuery _validQuery;

  public ShowDepositedAmountQueryHandlerTests()
  {
    _consolePrinter = new Mock<IConsoleWriter>();
    _userWallet = new Mock<IUserWallet>();
    _handler = new ShowDepositedAmountQueryHandler(
      _userWallet.Object, _consolePrinter.Object);
    _validQuery = new ShowDepositedAmountQuery();
  }

  [Fact]
  public async void Handle_PrintsUserCoins()
  {
    // Arrange

    var coins = new Dictionary<CoinType, int>
    {
      { CoinType.FiftyCent, 2 }
    };

    _userWallet.Setup(x => x.GetAllCoins()).Returns(coins);

    // Act
    await _handler.Handle(_validQuery, CancellationToken.None);

    // Assert
    _consolePrinter.Verify(x => x.PrintCoins(coins), Times.Once());
  }
}