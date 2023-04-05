# Hex arch
This is a simple example of a kind of hexagonal architecture.

## What is does
We have 4 clients, but they all do the same thing: Read CSV data and save it in a Sql Server database.
1. Command Line Interface `HexArch.Csv.Applications.Cli`: Reads a CSV file from the local system and saves it in a Sql Server database.
2. Minimal API `HexArch.Csv.Applications.MinimalApi`: Has an endpoint that receives the CSV data and saves it in the database.
3. Azure Function [Http Trigger] `HexArch.Csv.Applications.AzFn.HttpTrigger`: Same as the minimal API.
4. Azure Function [Timer Trigger] `HexArch.Csv.Applications.AzFn.TimerTrigger`: Reads a file from Azure Blob storage and saves it in the database.

The format the the CSV file is:
```csv
name,date of birth (yyyy-MM-dd)
```

Data example:
```csv
Noemie Dicki,1996-04-20
```


## How to install
You'll need .net6.0+ installed + Docker. Specifically for the TimerTrigger Azure Function, you'll need Azurite and Azure Storage Explorer installed.

- Azurite Install instructions: https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azurite
- Azure Storage Explorer: https://azure.microsoft.com/en-us/features/storage-explorer/

1. Using the terminal, go into the `docker` folder.
2. Run `build.bat` or run the command below:
```shell
docker build -t flywaysql .
```
3. Run `sqlserver_container.bat` or the command:
````shell
docker run --env-file env.list -p 1433:1433 --name sql2019 -d mcr.microsoft.com/mssql/server:2019-latest
````
4. Run `run_migrations.bat` to create the database or run the command:
```shell
docker run --rm --net="host" --name flyway --env-file env.list flywaysql -mixed="true" -url=jdbc:sqlserver://172.23.224.1:1433;encrypt=true;trustServerCertificate=true; -user=sa -password=just@demo#not4real migrate
```

Alternatively, you can run the file `setup_infra.bat` which will do all that work.

Once that's done, your database will be up and running with the tables created.

Fort this demo, I'm using user `sa` with the password `just@demo#not4real`. You can change that in the `env.list` file (and in the appsettings.json files).

After that you can run the applications and it will work. Remember: To run the TimerTrigger Azure Function, you'll need to have Azurite and Azure Storage Explorer installed.

# Baseline for Hexagonal Architecture
Here are some key concepts and principles of hexagonal architecture:

- **Core**: The core of the hexagonal architecture contains the domain logic or the business logic of the system. It represents 
the heart of the application and is responsible for implementing the business rules, business processes, and domain models.

- **Ports**: Ports define the interfaces that allow the core to communicate with the external world, including input ports and
output ports. Input ports are used to receive external requests and provide input to the core, while output ports are used
to send responses or notifications from the core to the external world.

- **Adapters**: Adapters are responsible for bridging the communication between the core and the external world. They are used
to convert external requests into a format that the core can understand, and vice versa. There are two types of adapters: 
inbound adapters, which handle incoming requests from the external world, and outbound adapters, which handle outgoing 
requests from the core to the external world.

- **Dependency Inversion Principle (DIP)**: Hexagonal architecture adheres to the DIP, which states that high-level modules 
should not depend on low-level modules, but both should depend on abstractions. This promotes loose coupling and allows 
for easy replacement of components without affecting the overall system.

- **Testability**: Hexagonal architecture promotes testability by separating the business logic from the external dependencies.
The core, being independent of the external world, can be easily tested in isolation using unit tests, while the adapters
can be tested separately using integration tests.

- **Flexibility**: Hexagonal architecture allows for flexibility in the system design by providing clear boundaries between the
core and the external dependencies. This makes it easier to swap out or replace external components, such as databases, user
interfaces, or external services, without affecting the core logic.

- **Modularity**: Hexagonal architecture promotes modularity by organizing the components of the system into separate, 
self-contained modules. Each module has a clear responsibility and can be developed, tested, and maintained independently, 
which makes the system easier to understand and maintain.

- **Domain-Driven Design (DDD)**: Hexagonal architecture is often used in conjunction with DDD principles, as it provides a
natural separation between the domain logic and the technical details of the system. This allows the development team to
focus on modeling the domain and implementing the business rules without being tightly coupled to the technical 
implementation.

Overall, hexagonal architecture provides a solid foundation for building complex, scalable, and maintainable software 
systems by promoting loose coupling, high modularity, and flexibility in the design and development process.
It allows for easy testing, extensibility, and adaptability, making it a popular choice among software architects
and developers for building robust and resilient applications. So, when designing a system architecture, consider 
hexagonal architecture as a viable option to ensure a well-organized and modular system. 

## Notes about this implementation 

## Diagrams
