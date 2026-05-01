# Flight Tracker app

## Setup instructions

Requires .NET runtime 10.0

```sh
cd Application/
dotnet run
```

## Project structure

```
.
├── Application - core application
│   ├── App.axaml
│   ├── App.axaml.cs
│   ├── Assets - Additional files
│   ├── Domain - Domain layer
│   ├── Restaurant.csproj
│   ├── Restaurant.sln
│   ├── Models - Data layer
│   ├── Persistence - Persistence layer
│   ├── Program.cs
│   ├── ViewLocator.cs
│   ├── ViewModels - all GUI logic
│   ├── Views - all GUI
│   └── app.manifest
├── Docs - additional asset files for README.md
├── README.md
└── Test - testing C# application
    ├── Assets - copy of original assets folder
    ├── Test.csproj
    ├── TestAppBuilder.cs
    └── UnitTest1.cs
```

## Architecture diagram

## Component documentation
