﻿using MediatR;

namespace VendingMachine.Mediator;

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
    public async Task<dynamic> SendAsync<TCommand, TResponse>(
        TCommand command) where TCommand : IRequest<TResponse>
    {
        var mediatorResponse = await _mediator.Send(command);

        return mediatorResponse;
    }
}
