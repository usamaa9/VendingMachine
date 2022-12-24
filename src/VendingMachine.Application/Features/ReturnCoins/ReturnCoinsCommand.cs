using MediatR;

namespace VendingMachine.Application.Features.ReturnCoins;

/// <summary>
/// Command to return all user coins.
/// <seealso cref="ReturnCoinsCommandHandler"/>
/// </summary>
public class ReturnCoinsCommand : IRequest<Unit>
{
}