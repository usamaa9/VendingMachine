﻿using VendingMachine.Application.Entities;

namespace VendingMachine.Application.IOHelpers;

public interface IConsolePrinter
{
  void DisplayMenu();
  void AskUserForMenuChoice();
  void InvalidMenuChoiceMessage();
  void ExitMessage();
  void AskUserForCoinType();
  void AskUserForCoinQuantity();
  void InvalidCoinTypeMessage();
  void InvalidCoinQuantityMessage();
  void AskForProductName();
  void DisplayProducts(List<VendingMachineProduct> products);
}