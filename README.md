# AdventureWorksAPI

I have created this application to support the FE when data is required for the Adventure works front end.

I have a controller for poruduct operations and a controller for sales operations

Each controller calls a service which in turn calles a repostiory layer for data access

I have used inversion of control to allow the service and repository to be swapped out in the furture for new implementeations if required.

I have also used view models to give me control of the data returned in the API calls. 

To run this application you will need to download the AdventureWorks database from here https://github.com/Microsoft/sql-server-samples/releases/download/adventureworks/AdventureWorks2019.bak and restore the database.  You will also have to create a new user and modify the connection string in appsettings.json fileas the one in the connection string is created by me.

Once you have done that just run the applicaition and it will be ready to serve data for the FE angualr project
