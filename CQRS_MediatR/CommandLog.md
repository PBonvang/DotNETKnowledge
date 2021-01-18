
dotnet new WebApi -o Api
dotnet new ClassLib -o Services
dotnet new sln
dotnet sln CQRS_MediatR.sln add Api Services

dotnet add Services package MediatR -v 9.0.0
dotnet add Api package MediatR -v 9.0.0
dotnet add Api package MediatR.Extensions.Microsoft.DependencyInjection -v 9.0.0
dotnet add Api reference Services

dotnet new ClassLib -o DataAccess
dotnet add Services reference DataAccess
dotnet add DataAccess/ package Microsoft.EntityFrameworkCore.Sqlite -v 5.0.2
dotnet sln CQRS_MediatR.sln add DataAccess
dotnet add DataAccess/ package Microsoft.EntityFrameworkCore.Design -v 5.0.2
dotnet ef migrations add InitialStructure -p DataAccess/
dotnet ef database update -p DataAccess/
dotnet add Api/ reference DataAccess/

dotnet add Services/ package AutoMapper -v 10.1.1
dotnet add Services/ package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add Api/ package AutoMapper
dotnet add Api/ package AutoMapper.Extensions.Microsoft.DependencyInjection