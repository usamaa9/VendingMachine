using VendingMachine.Application.Features.Events.ProductBought;

namespace VendingMachine.Application.UnitTests.Features.Events.ProductBought;

public class ChangeRemoverEventHandlerTests
{
  private readonly ChangeRemoverEventHandler _handler;
  private readonly Mock<IMachineWallet> _machineWallet;
  private readonly ProductBoughtEvent _validEvent;

  public ChangeRemoverEventHandlerTests()
  {
    _machineWallet = new Mock<IMachineWallet>();
    _handler = new ChangeRemoverEventHandler(_machineWallet.Object);
    _validEvent = new ProductBoughtEvent
    {
      ChangeCoins = new Dictionary<CoinType, int>
      {
        { CoinType.FiftyCent, 4 }
      }
    };
  }

  [Fact]
  public async void Handle_RemovesCoinsFromMachineWallet()
  {
    // Act
    await _handler.Handle(_validEvent, CancellationToken.None);

    // Assert
    _machineWallet.Verify(
      x => x.RemoveCoins(CoinType.FiftyCent, 4), Times.Once);
  }
}