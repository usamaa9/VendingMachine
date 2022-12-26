﻿using MediatR;
using VendingMachine.Application.Models;
using VendingMachine.Application.Persistence;

namespace VendingMachine.Application.Features.Commands.ReturnCoins;

public class ReturnCoinsCommandHandler : IRequestHandler<ReturnCoinsCommand, Result<Unit>>
{
  private readonly IUserWallet _userWallet;

  public ReturnCoinsCommandHandler(IUserWallet userWallet)
  {
    _userWallet = userWallet;
  }

  public Task<Result<Unit>> Handle(ReturnCoinsCommand request, CancellationToken cancellationToken)
  {
    _userWallet.RemoveAllCoins();

    return Task.FromResult(Result.From(Unit.Value));
  }
}