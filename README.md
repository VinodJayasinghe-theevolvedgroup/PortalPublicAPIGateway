
This is a Proof of Concept solution for Consume Public API to Portal's Sub Applications String with ASP.NET Core 3 following the principles of Clean Architecture.


## Technologies
* .NET Core 3.1
* ASP .NET Core 3.1
* MediatR + CQRS
* SwaggerUI

## Overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.
**Currently, We dont have a domain logic but in future we can add more entites once finalize the domain.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.
**Used CQRS Pattern to seperate the application logic or for this instance, We can seperate the each public Apis for each requierements. 

### Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.
**For the POC I've added the Identity layer using API Key to this layer, We can update the identity layer once we finalyze the authentication & authorization model 

### WebUI

This layer is a ASP.NET Core 3.1 Web API with a Empty Solution. This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only *Startup.cs* should reference Infrastructure.
**Used SwaggerUI to demonstrate the API schemas, Results, Authentication/Authourization and Error Handling.

## Notes

### Run the Application
* Cloned the Repository to your local machine
* Open the solution using Visual Studio
* Give a Re-Build
* Run on IIS
* Go to the Swagger index page (Ex: https://localhost:44391/swagger/index.html)

