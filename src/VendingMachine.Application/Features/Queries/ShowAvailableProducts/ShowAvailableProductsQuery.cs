using MediatR;
using VendingMachine.Application.Entities;
using VendingMachine.Application.Models;

namespace VendingMachine.Application.Features.Queries.ShowAvailableProducts;

/// <summary>
/// Query to get all available products.
/// <seealso cref="ShowAvailableProductsQueryHandler"/>
/// </summary>
public class ShowAvailableProductsQuery : IRequest<Result<List<VendingMachineProduct>>>
{
}