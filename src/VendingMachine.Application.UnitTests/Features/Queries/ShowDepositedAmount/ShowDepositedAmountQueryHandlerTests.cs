﻿using Moq;
using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Features.Queries.ShowDepositedAmount;
using VendingMachine.Application.IOHelpers;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.UnitTests.Features.Queries.ShowDepositedAmount;

public class ShowDepositedAmountQueryHandlerTests
{
  private readonly ShowDepositedAmountQueryHandler _handler;
  private readonly Mock<IConsolePrinter> _mockConsolePrinter;
  private readonly Mock<IUserWallet> _mockUserWallet;
  private readonly ShowDepositedAmountQuery _validQuery;

  public ShowDepositedAmountQueryHandlerTests()
  {
    _mockConsolePrinter = new Mock<IConsolePrinter>();
    _mockUserWallet = new Mock<IUserWallet>();
    _handler = new ShowDepositedAmountQueryHandler(
      _mockUserWallet.Object, _mockConsolePrinter.Object);
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

    _mockUserWallet.Setup(x => x.GetAllCoins()).Returns(coins);

    // Act
    await _handler.Handle(_validQuery, CancellationToken.None);

    // Assert
    _mockConsolePrinter.Verify(x => x.PrintCoins(coins), Times.Once());
  }
}