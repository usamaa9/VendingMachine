﻿using MediatR;
using VendingMachine.Persistence;

namespace VendingMachine.GetAvailableProducts;

internal class GetAvailableProductsQueryHandler : IRequestHandler<GetAvailableProductsQuery, Unit>
{
    private readonly IProductRepository _productRepository;

    public GetAvailableProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<Unit> Handle(GetAvailableProductsQuery request, CancellationToken cancellationToken)
    {
        // Display all the products here using the productsRepo
        _productRepository.DisplayAllProducts();
        return Task.FromResult(Unit.Value);
    }
}
