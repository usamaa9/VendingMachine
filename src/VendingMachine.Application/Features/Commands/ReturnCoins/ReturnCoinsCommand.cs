using MediatR;

namespace VendingMachine.Application.Features.Commands.ReturnCoins;

/// <summary>
/// Command to return all user coins.
/// <seealso cref="ReturnCoinsCommandHandler"/>
/// </summary>
public class ReturnCoinsCommand : IRequest<Unit>
{
}