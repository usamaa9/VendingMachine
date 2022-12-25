using MediatR;
using VendingMachine.Application.Models;

namespace VendingMachine.Application.Features.Commands.ReturnCoins;

/// <summary>
/// Command to return all user coins.
/// <seealso cref="ReturnCoinsCommandHandler"/>
/// </summary>
public class ReturnCoinsCommand : IRequest<Result<Unit>>
{
}