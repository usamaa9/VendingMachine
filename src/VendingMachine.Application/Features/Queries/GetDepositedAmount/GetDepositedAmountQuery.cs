using MediatR;
using VendingMachine.Application.Enumerations;
using VendingMachine.Application.Models;

namespace VendingMachine.Application.Features.Queries.GetDepositedAmount;

/// <summary>
/// Query for displaying User's deposited amount
/// <seealso cref="GetDepositedAmountQueryHandler"/>
/// </summary>
public class GetDepositedAmountQuery : IRequest<Result<Dictionary<CoinType, int>>>
{
}