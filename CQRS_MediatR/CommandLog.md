
dotnet new WebApi -o Api
dotnet new ClassLib -o Services
dotnet new sln
dotnet sln CQRS_MediatR.sln add Api Services

dotnet add Services package MediatR --version 9.0.0
dotnet add Api package MediatR --version 9.0.0
dotnet add Api package MediatR.Extensions.Microsoft.DependencyInjection --version 9.0.0
dotnet add Api reference Services

dotnet new ClassLib -o DataAccess
dotnet add Services reference DataAccess
dotnet add DataAccess/ package Microsoft.EntityFrameworkCore.Sqlite --version 5.0.2
dotnet sln CQRS_MediatR.sln add DataAccess
dotnet add DataAccess/ package Microsoft.EntityFrameworkCore.Design --version 5.0.2
dotnet ef migrations add InitialStructure -p DataAccess/
dotnet ef database update -p DataAccess/