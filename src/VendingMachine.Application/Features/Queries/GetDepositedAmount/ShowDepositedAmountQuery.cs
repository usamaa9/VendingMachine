using MediatR;
using VendingMachine.Application.Models;

namespace VendingMachine.Application.Features.Queries.GetDepositedAmount;

/// <summary>
/// Query for displaying User's deposited amount
/// <seealso cref="ShowDepositedAmountQueryHandler"/>
/// </summary>
public class ShowDepositedAmountQuery : IRequest<Result<Unit>>
{
}