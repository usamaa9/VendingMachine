using MediatR;

namespace VendingMachine.Application.Mediator;

public interface ICommandBus
{
    /// <summary>
    /// Send a command and returns the corresponding response.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command that is being sent.</typeparam>
    /// <typeparam name="TResponse">The type of the response that should be received.</typeparam>
    /// <param name="command">The command that is being sent.</param>
    /// <returns>The response.</returns>
    Task<dynamic> SendAsync<TCommand, TResponse>(
        TCommand command) where TCommand : IRequest<TResponse>;

    Task PublishAsync<TNotification>(TNotification notification) where TNotification : INotification;
}
