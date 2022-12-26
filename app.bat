cd src
dotnet publish -c Release -o ..\publish
cd ..\publish
cls
dotnet VendingMachine.App.dll
