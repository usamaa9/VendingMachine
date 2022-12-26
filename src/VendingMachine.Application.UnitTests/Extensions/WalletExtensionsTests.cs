using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Extensions;

namespace VendingMachine.Application.UnitTests.Extensions;

public class WalletExtensionsTests
{
  [Fact]
  public void AddCoins_AddsCoinsToWallet()
  {
    // Arrange
    var wallet = new Dictionary<CoinType, int>();

    // Act
    wallet.AddCoins(CoinType.TenCent, 3);

    // Assert
    Assert.Equal(3, wallet[CoinType.TenCent]);
  }

  [Fact]
  public void AddCoins_AddsCoinsToExistingWallet()
  {
    // Arrange
    var wallet = new Dictionary<CoinType, int>
    {
      { CoinType.TenCent, 5 }
    };

    // Act
    wallet.AddCoins(CoinType.TenCent, 3);

    // Assert
    Assert.Equal(8, wallet[CoinType.TenCent]);
  }

  [Fact]
  public void RemoveCoins_RemovesCoinsFromWallet()
  {
    // Arrange
    var wallet = new Dictionary<CoinType, int>
    {
      { CoinType.TenCent, 5 }
    };

    // Act
    wallet.RemoveCoins(CoinType.TenCent, 3);

    // Assert
    Assert.Equal(2, wallet[CoinType.TenCent]);
  }

  [Fact]
  public void RemoveCoins_RemovesCoinsUntilEmpty()
  {
    // Arrange
    var wallet = new Dictionary<CoinType, int>
    {
      { CoinType.TenCent, 5 }
    };

    // Act
    wallet.RemoveCoins(CoinType.TenCent, 5);

    // Assert
    Assert.Equal(0, wallet[CoinType.TenCent]);
  }

  [Fact]
  public void TotalAmount_ReturnsCorrectTotal()
  {
    // Arrange
    var wallet = new Dictionary<CoinType, int>
    {
      { CoinType.TenCent, 3 },
      { CoinType.TwentyCent, 2 },
      { CoinType.FiftyCent, 1 },
      { CoinType.OneEuro, 2 }
    };

    // Act
    var result = wallet.TotalAmount();

    // Assert
    Assert.Equal(3.2m, result);
  }

  [Fact]
  public void GetAmountInCoins_ReturnsCorrectCoins()
  {
    // Arrange
    var wallet = new Dictionary<CoinType, int>
    {
      { CoinType.TenCent, 3 },
      { CoinType.TwentyCent, 2 },
      { CoinType.FiftyCent, 1 },
      { CoinType.OneEuro, 2 }
    };

    // Act
    var result = wallet.GetAmountInCoins(1.8m);

    // Assert
    Assert.Equal(1, result[CoinType.OneEuro]);
    Assert.Equal(1, result[CoinType.FiftyCent]);
    Assert.Equal(1, result[CoinType.TwentyCent]);
    Assert.Equal(1, result[CoinType.TenCent]);
  }

  [Fact]
  public void GetAmountInCoins_CoinNotInWallet_ThrowsException()
  {
    // Arrange
    var wallet = new Dictionary<CoinType, int>
    {
      { CoinType.TenCent, 0 },
      { CoinType.TwentyCent, 2 },
      { CoinType.FiftyCent, 1 },
      { CoinType.OneEuro, 2 }
    };

    // Act
    var act = () => wallet.GetAmountInCoins(0.1m);

    // Assert
    Assert.Throws<Exception>(act);
  }

  // TODO: add tests for when it has to give a different configuration
}