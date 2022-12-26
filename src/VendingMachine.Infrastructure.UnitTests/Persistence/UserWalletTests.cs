namespace VendingMachine.Infrastructure.UnitTests.Persistence;

public class UserWalletTests
{
  private readonly UserWallet _sut;

  public UserWalletTests()
  {
    _sut = new UserWallet();
  }

  [Fact]
  public void CanAddCoinsToWallet()
  {
    // Arrange
    var coinType = CoinType.TwentyCent;
    var quantity = 10;

    // Act
    _sut.AddCoins(coinType, quantity);

    // Assert
    Assert.True(_sut.Wallet.ContainsKey(coinType));
    Assert.Equal(quantity, _sut.Wallet[coinType]);
  }

  [Fact]
  public void CanClearWallet()
  {
    // Arrange
    _sut.AddCoins(CoinType.TwentyCent, 10);
    _sut.AddCoins(CoinType.TenCent, 5);

    // Act
    _sut.RemoveAllCoins();

    // Assert
    Assert.Empty(_sut.Wallet);
  }

  [Fact]
  public void CanCalculateTotalAmount()
  {
    // Arrange
    _sut.AddCoins(CoinType.FiftyCent, 4);
    _sut.AddCoins(CoinType.TwentyCent, 2);
    _sut.AddCoins(CoinType.TenCent, 1);

    // Act
    var totalAmount = _sut.TotalAmount();

    // Assert
    Assert.Equal(2.50m, totalAmount);
  }

  [Fact]
  public void CanGetAllCoins()
  {
    // Arrange
    _sut.AddCoins(CoinType.FiftyCent, 4);
    _sut.AddCoins(CoinType.TwentyCent, 2);
    _sut.AddCoins(CoinType.TenCent, 1);

    // Act
    var coins = _sut.GetAllCoins();

    // Assert
    Assert.Equal(4, coins[CoinType.FiftyCent]);
    Assert.Equal(2, coins[CoinType.TwentyCent]);
    Assert.Equal(1, coins[CoinType.TenCent]);
  }
}