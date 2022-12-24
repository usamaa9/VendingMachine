using MediatR;

namespace VendingMachine.Application.Features.ShowDepositedAmount;

/// <summary>
/// Query for displaying User's deposited amount
/// <seealso cref="ShowDepositedAmountQueryHandler"/>
/// </summary>
public class ShowDepositedAmountQuery : IRequest<Unit>
{
}