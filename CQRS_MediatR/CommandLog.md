
dotnet new WebApi -o Api
dotnet new ClassLib -o Services
dotnet new sln
dotnet sln CQRS_MediatR.sln add Api Services

dotnet add Services package MediatR --version 9.0.0
dotnet add Api package MediatR --version 9.0.0
dotnet add Api package MediatR.Extensions.Microsoft.DependencyInjection --version 9.0.0
dotnet add Api reference Services