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

## Sources
- https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs