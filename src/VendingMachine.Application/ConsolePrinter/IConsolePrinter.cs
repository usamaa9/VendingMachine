﻿namespace VendingMachine.Application.ConsolePrinter;

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
}