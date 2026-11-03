# Unit8_SRP_F24

## Requirements

- .NET 10 SDK
- Visual Studio Code with the C# Dev Kit extension
- A configured SQL Server database for trade storage

Both projects target `net10.0`. This targets the .NET 10 release without pinning
the project to a particular .NET 10 patch version.

## Open and run in Visual Studio Code

Open this repository folder in VS Code. In the integrated terminal, build the
solution and run the sample application with:

```powershell
dotnet build Unit8_SRP_F24.sln
dotnet run --project Unit8_SRP_F24/Unit8_SRP_F24.csproj
```

Run the test project with:

```powershell
dotnet test Unit8_SRP_F24.sln
```

The sample writes trades to a LocalDB database using the connection string in
`TradeProcessor.cs`. The integration test also queries Azure SQL using the
connection string in `TradeProcessorTests.cs`. Configure both for databases
available in your environment before running the application or tests; the test
inserts trade records.