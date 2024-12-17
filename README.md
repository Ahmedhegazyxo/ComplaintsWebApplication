1. APP SETUP
     - Install SQL Server on the local machine, Make sure to Access the SQL SERVER instance and ensure it works properly from background tasks.
     - Migrations folder is included on the web app, It has all the database metadata.
     - To apply the migrations to the SQL SERVER instance installed on the machine apply the command(update-database) in the package manager console from Visual Studio.
     - If any problem issued the command ensure the SQL SERVER connection string in appsettings.json
2. SOLUTION ARCHETICTURE
     - BASE
       . All entities, project resources which can be used in the client project (very important to be built as a DLL for Client side usage in case of using .NET Framework).
     - COMPLAINSSERVER
       . Server side services which communicates with the database instance installed on (Local / Server) machine.
       . Entity Configurations which is applied in the DBContext to edit Database metadata.
       . API Controllers which acts as a pipeline to access the services
       . DPI Container to install services and it's dependants (Singleton / Scoped / Transient)
