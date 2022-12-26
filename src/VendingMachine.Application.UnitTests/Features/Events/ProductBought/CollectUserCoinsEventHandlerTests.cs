using VendingMachine.Application.Features.Events.ProductBought;

namespace VendingMachine.Application.UnitTests.Features.Events.ProductBought;

public class CollectUserCoinsEventHandlerTests
{
  private readonly CollectUserCoinsEventHandler _handler;
  private readonly Mock<IMachineWallet> _machineWallet;
  private readonly Mock<IUserWallet> _userWallet;
  private readonly ProductBoughtEvent _validEvent;

  public CollectUserCoinsEventHandlerTests()
  {
    _machineWallet = new Mock<IMachineWallet>();
    _userWallet = new Mock<IUserWallet>();
    _handler = new CollectUserCoinsEventHandler(
      _userWallet.Object, _machineWallet.Object);
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
    _machineWallet.Verify(
      x => x.AddCoins(CoinType.FiftyCent, 4), Times.Once);
    _userWallet.Verify(x => x.RemoveAllCoins(), Times.Once());
  }
}