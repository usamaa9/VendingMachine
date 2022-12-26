namespace VendingMachine.Infrastructure.UnitTests.Persistence;

public class MachineWalletTests
{
  private readonly MachineWallet _sut;

  public MachineWalletTests()
  {
    _sut = new MachineWallet();
  }

  [Fact]
  public void AddCoins_AddsCoinsToTheWallet()
  {
    // Arrange

    // Act
    _sut.AddCoins(CoinType.TenCent, 2);

    // Assert
    Assert.Equal(2, _sut.Wallet[CoinType.TenCent]);
  }

  [Fact]
  public void RemoveCoins_RemovesCoinsFromTheWallet()
  {
    // Arrange
    _sut.AddCoins(CoinType.TenCent, 2);

    // Act
    _sut.RemoveCoins(CoinType.TenCent, 1);

    // Assert
    Assert.Equal(1, _sut.Wallet[CoinType.TenCent]);
  }

  [Fact]
  public void CanGiveChange_ReturnsTrueIfChangeCanBeGiven()
  {
    // Arrange
    _sut.AddCoins(CoinType.TenCent, 2);

    // Act
    var canGiveChange = _sut.CanGiveChange(0.2m, out var coins);

    // Assert
    Assert.True(canGiveChange);
    Assert.Equal(2, coins![CoinType.TenCent]);
  }

  [Fact]
  public void CanGiveChange_ReturnsFalseIfChangeCannotBeGiven()
  {
    // Arrange
    _sut.AddCoins(CoinType.TenCent, 2);

    // Act
    var canGiveChange = _sut.CanGiveChange(0.3m, out var coins);

    // Assert
    Assert.False(canGiveChange);
    Assert.Null(coins);
  }
}