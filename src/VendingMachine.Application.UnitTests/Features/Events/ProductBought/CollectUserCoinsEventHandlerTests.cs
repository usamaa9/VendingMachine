using Moq;
using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Features.Events.ProductBought;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.UnitTests.Features.Events.ProductBought;

public class CollectUserCoinsEventHandlerTests
{
  private readonly CollectUserCoinsEventHandler _handler;
  private readonly Mock<IMachineWallet> _mockMachineWallet;
  private readonly Mock<IUserWallet> _mockUserWallet;
  private readonly ProductBoughtEvent _validEvent;

  public CollectUserCoinsEventHandlerTests()
  {
    _mockMachineWallet = new Mock<IMachineWallet>();
    _mockUserWallet = new Mock<IUserWallet>();
    _handler = new CollectUserCoinsEventHandler(
      _mockUserWallet.Object, _mockMachineWallet.Object);
    _validEvent = new ProductBoughtEvent
    {
      UserCoins = new Dictionary<CoinType, int>
      {
        { CoinType.FiftyCent, 4 }
      },
      ChangeCoins = new Dictionary<CoinType, int>
      {
        { CoinType.FiftyCent, 4 }
      }
    };
  }

  [Fact]
  public async void Handle_AddsUserCoinsToMachineWallet()
  {
    // Act
    await _handler.Handle(_validEvent, CancellationToken.None);

    // Assert
    _mockMachineWallet.Verify(
      x => x.AddCoins(CoinType.FiftyCent, 4), Times.Once);
    _mockUserWallet.Verify(x => x.RemoveAllCoins(), Times.Once());
  }
}