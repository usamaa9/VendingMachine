namespace VendingMachine.App.Mediator;

public class CommandBus : ICommandBus
{
  private readonly IMediator _mediator;

  /// <summary>
  /// Initializes a new instance of the <see cref="CommandBus"/> class.
  /// </summary>
  /// <param name="mediator"></param>
  public CommandBus(IMediator mediator)
  {
    _mediator = mediator;
  }

  /// <inheritdoc/>
  public async Task<Result<TResponse>> SendAsync<TCommand, TResponse>(
    TCommand command) where TCommand : IRequest<Result<TResponse>>
  {
    var mediatorResponse = await _mediator.Send(command);

    return mediatorResponse;
  }


  public async Task PublishAsync<TNotification>(TNotification notification) where TNotification : INotification
  {
    await _mediator.Publish(notification);
  }
}