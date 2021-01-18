# CQRS with MediatR learnings

## CQRS - Command Query Responsibility Segregation
CQRS is the concept of separating read(queries) and write(command) operations into separate domains.  
This means that you can have the querying part of a service built optimized for reading data and presenting it. The same goes for the commanding part of the service. If you've worked with the standard MVC framework you will know the struggle of using one data accessing method, and have probably run into slow reads because of ORMs or lots of boiler plate to have the write and read structure compatible or alike.  
CQRS has the following advantages:
- Independent scaling: As the two request types are split into different layers, it's possible to scale each independently of each other. This point is especially useful if you split the two layers into separate micro-services, that way you will be able to use your service orchestrator to do it without even changing the code.
- Security: CQRS enables you to delegate access to reading and writing without having to specify policies on every endpoint.
- Optimized data schemas: It makes it possible to read from an optimized read data store like a materialized view or cache, while writing can be done to a write optimized data store like a database.
- Simpler queries: By having separate models for reading and writing, the complex parsing and mapping for shared models isn't needed and over fetching and posting can be avoided. It also makes complex sql statements redundant as we can read from a materialized view or document database and map it directly to the query result.  
Disadvantages: 
- Increased complexity: CQRS might seem simple upfront but can lead to confusion as "one" system has multiple data stores, models and entities. With the introduction of event sourcing it becomes even more complex.
- Eventual consistency: As the read and write data stores might be different it's crucial to have the different stores synchronized.  

## MediatR
The MediatR nuget package provides the necessary functionality to implement the *[mediator pattern](https://en.wikipedia.org/wiki/Mediator_pattern)* in a .NET application.  
It does this by providing 4 interfaces:  
**IMediator**: Injected into controllers and used to send requests.  
**IRequest<RESPONSE_TYPE>**: Used for requests which in the terms of CQRS are commands and queries.  
In case you wish to return nothing from the request use the *Unit* type.  
**IRequestHandler<REQUEST_TYPE, RESPONSE_TYPE>**: Used as the executor of the requests. Includes the *Handle* method used to execute the request. The handler is where dependencies and functionality are present.  
**IPipelineBehavior<TIn,TOut>**: Used to create middleware/pipeline behavior for requests. When added to the scope the pipes will be used ordered from top to bottom.  

**My experiences:**  
- While debugging you have to set break points in the handlers to stop there. You cannot step over or into and get to the handler.

## Structural decisions
### Request and request handlers
Requests and request handlers are placed in the same file, as this will allow us to inject the dependencies without having to create an ocean of files. This is a test, something I wish to try.  
My experiences:  

### Working in dev container
This project is created entirely in the dev container, this is to be able to have a shared and indentical development environment between developers.
My experiences:  
- Omnisharp has to be restarted quite frequently, basically everytime I switch between files in different projects.  
**Error:** Can't find custom attr constructor image: /workspaces/DotNETLearningProjects/CQRS_MediatR/Services/bin/Debug/net5.0/Services.dll mtoken: 0x0a000001 due to: Cannot resolve dependency to assembly because it has not been preloaded. When using the ReflectionOnly APIs, dependent assemblies must be pre-loaded or loaded on demand through the ReflectionOnlyAssemblyResolve event.
- Dotnet tools aren't installed when installed in DockerFile.  
**Error:** Placed *RUN dotnet tool install -g dotnet-ef* in the DockerFile, then after building *dotnet tool list -g* show that it's not installed.  
**Work around:**
1. Set the PATH environment variable in the DockerFile: *ENV PATH="${PATH}:/home/vscode/.dotnet/tools"*
2. Add the installation of the tool in the postCreateCommand: *dotnet tool install -g dotnet-ef && dotnet restore*


## Sources
- https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs
- https://www.youtube.com/watch?v=xKKVW94F2bc