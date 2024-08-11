# adventureworksmicroservice
This repository contains a sample microservice project along with the AdventureWorks database.

## Database Choise

Since the AdventureWorks database is necessary and we will be dealing with real-time transactions, we downloaded the AdventureWorks OLTP version.

Then, we download and install the 2022 image of MSSQL.

Commands:
```
"docker pull mcr.microsoft.com/mssql/server"
"docker run -e `ACCEPT_EULA=Y` -e `SA_PASSWORD`=12345678.. -p 15432:1433 --name adventureworksdev -d mcr.microsoft.com/mssql/server"
```
In the command above, we accept the agreement with ACCEPT_EULA. 
With SA_PASSWORD, we set a password for the sa user. 
The -p option specifies that we will access the 1433 port in the container environment through the 15432 port on our host machine. 
The -d option indicates that it will run in the background.

We check if there is a running container using the `docker ps` command.

Output:

| CONTAINER ID | IMAGE | COMMAND | CREATED | STATUS | PORTS | NAMES |
|--------------|-------|---------|---------|--------|-------|-------|
|              |       |         |         |        |       |       |  

Since no running container is listed, let's use the `docker logs <container_id>` command to check the error logs.

Commands:
```
docker logs c24
```
Output:
> ERROR: Unable to set system administrator password: Password validation failed. The password does not meet SQL Server password policy requirements because it is not complex enough. The password must be at least 8 characters long and contain characters from three of the following four sets: Uppercase letters, Lowercase letters, Base 10 digits, and Symbols


Among the logs, we see that the password we entered is not complex enough, which is why the container could not start.

Let's remove the existing container and recreate it with a new password.

Commands:
```
docker rm c24
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=AdventurePass*123" -p  15432:1433 --name adventureworksdev -d mcr.microsoft.com/mssql/server

```
Output:
> 1ebb39c142dd96ad818609975054a3d3c4bc4bd43991450dbbf82fe08102e1a8

Let's check:

Command:

```
docker ps
```
Output:
| CONTAINER ID | IMAGE                          | COMMAND                | CREATED                | STATUS              | PORTS                        | NAMES                  |
|--------------|--------------------------------|------------------------|------------------------|---------------------|------------------------------|------------------------|
| 1ebb39c142dd | mcr.microsoft.com/mssql/server | "/opt/mssql/bin/perm…" | 47 seconds ago         | Up 46 seconds       |0.0.0.0:15432->1433/tcp       |    adventureworksdev   |
         
We see that our container has been running for 47 seconds.

The next step is to connect using `Azure Data Studio`.

![Picture](./assessts/images/Picture_1.png)

As seen, the connection was established.

When using `Azure Data Studio` the restore process can be a bit cumbersome. Therefore, after a brief search, we discovered an alternative method: transferring our backup file from the local machine to the container.


Let's give it a try.
Command 
> docker cp <source_path> <container_id>:<container_destination_path>

```
docker cp C:\Users\memin\Downloads\AdventureWorks2022.bak 1ebb:/var/backups/AdventureWorks2022.bak
```
Output:
> Successfully copied 210MB to 1ebb:/var/backups/AdventureWorks2022.bak

We see that the file was successfully copied to `/var/backups` within the container.

Next, to use the restore feature in `Azure Data Studio`, we check the "Enable preview features" option in the "Settings." Additionally, we see the restored database under "Databases."

![Picture](./assessts/images/Picture_2.png)

## File Structure And Role Definitions of Microservice Applications According To The DDD (Domain-Driven Design) Pattern

> We will create five microservices soon. But first, we need to define the file structures for these services. We know that most microservice projects are created using the DDD pattern.

> Please look at the below and try to understand the folder structure I shared.

![Picture](./assessts/images/Picture_3.png)

## DOMAIN
### Entities
> This folder contains the core entities that represent the business logic of the system. Entities are defined as long-lived business objects with a unique identity.
### ValueObjects
> Value objects are objects that do not have identities and are defined solely by their values. In this folder, various value objects in the system (such as Address, Email) are defined.
### Agregates
> This folder defines aggregates, which are components that contain multiple entities and are treated as a whole. An aggregate root is the access point for the other entities within this aggregate.
### Services
> This folder contains domain services that perform operations across entities. These services are used to implement business rules that affect multiple entities.
### Exceptions
> Custom exceptions used in the domain layer are defined in this folder. Error management related to the domain is handled through these exceptions.

## APPLICATION
### Commands
> Commands are requests that represent an action in the system and change its state. Examples such as CreateEmployeeCommand may be found in this folder.
### Queries
> Queries are requests used to obtain data and typically do not alter the state of the system. For example, GetEmployeeByIdQuery.
### DTOs (Data Transfer Objects)
> DTOs are structures used to facilitate the transfer of data from one layer to another. In the application layer, these objects used for data transfer are defined here.

## INFRASTRUCTURE
### Persistence
> This folder contains all components related to database access and persistence. Database connections and ORM (Object-Relational Mapping) configurations are located here.
### Repositories
> Repositories act as intermediaries between the data access layer and the domain layer. This folder includes repository interfaces and implementations where database operations are performed.
### ExternalServices
> Interaction with external services (such as third-party APIs) is carried out in this folder. Components used for integration with other systems are defined here.

## API
### Controllers
> This folder defines the interaction points (API endpoints) between the application and the outside world. Controllers that handle incoming HTTP requests are found here.
### Middlewares
> Middleware are pieces of software that come into play during the processing of incoming requests, filtering or modifying them. This folder defines the middleware components used at the API level.

## TESTS
### Tests
> Tests are units written to ensure the correctness and reliability of the application. This folder contains unit and integration tests for various layers of the system.



# Adapting Databases to Microservices

> To use the AdventureWorks database in a microservices architecture, you can split tables between different microservices and even across different databases. However, Foreign Key (FK) constraints defined between schemas are an important consideration in this process. Maintaining Foreign Key relationships between tables spread across different databases is generally neither feasible nor recommended.

> You will need to remove Foreign Key constraints between tables that you plan to move to different databases.



Temp:
Scaffold-DbContext "Data Source=localhost,15432;Initial Catalog=AdventureWorks2022;Persist Security Info=True;User ID=sa;Password=AdventurePass*123;Encrypt=True;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Infrastructure/Persistence -Context AdventureWorksContext