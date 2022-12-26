using Moq;
using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Features.Events.ProductBought;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.UnitTests.Features.Events.ProductBought;

public class ChangeRemoverEventHandlerTests
{
  private readonly ChangeRemoverEventHandler _handler;
  private readonly Mock<IMachineWallet> _mockMachineWallet;
  private readonly ProductBoughtEvent _validEvent;

  public ChangeRemoverEventHandlerTests()
  {
    _mockMachineWallet = new Mock<IMachineWallet>();
    _handler = new ChangeRemoverEventHandler(_mockMachineWallet.Object);
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
    _mockMachineWallet.Verify(
      x => x.RemoveCoins(CoinType.FiftyCent, 4), Times.Once);
  }
}