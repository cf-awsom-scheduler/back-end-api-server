# Awsom Scheduler API (back-end)

This is the back-end API code for the Awsom Scheduler, written in C# .NET Core 2.2.

The project uses Entity Framework Core for database access and modification and uses a Microsoft SQL Server database.

## Setup and Deployment

### Requirements
- Server capable of hosting a .NET Core 2.2 application
- Microsoft SQL Server (and connection string)

### Environment / Configuration variables
- `Secret` - Secret key for securely signing JSON Web Tokens
- `ConnectionStrings:ProductionConnection` - Connection string for the running SQL server

### Deployment

#### 1. GitHub
1. Navigate to our GitHub page for the back-end code
    - [Awsom Scheduler Back-End Repo](https://github.com/cf-awsom-scheduler/back-end-api-server)
2. Fork the repository

**The `deploy` branch is the one which is used for deployment.**

#### 2. Azure
1. Navigate to the Azure Dashboard, then to App Services
2. `Add` a new app
3. Select a `Subscription` and `Resource Group`
4. Enter an instance name
5. For the remaining options, choose the following
    - `Publish`: Code
    - `Runtime stack`: .NET Core 2.2
    - `Operating system`: Windows (preferred) or Linux
    - `Region`: (as desired)
6. Choose an `App Service Plan`
7. Click `Review and create`
8. (Wait for the app to deploy on Azure... probably get a cup of coffee or tea)
9. Navigate into the newly-created app's dashboard and then click `Deployment Center` from the menu
10. Choose `GitHub` for deployment and click `Continue`
    - If you haven't done it before, you will need to provide Azure with access to your GitHub repositories
12. Choose `App Service build service` and click `Continue`
13. Find the forked repository you created above
    - `Organization` will be your username or the organization you used create the fork
    - `Repository` will be the forked repo
    - `Branch` will be `deploy`
14. Click `Continue`
15. Click `Finish`
16. On the app dashboard (left side), click `Configuration`
17. In `Application Settings`, create a new application setting named `Secret` with a value of your choosing, then click `OK`
18. In `Connection Strings`, create a new connection string named `ProductionConnection` with a value that will let you connect to your running Microsoft SQL Server, then click `OK`
    - The SQL database will need to be configured using the code-first schemas in this project. This is a process which is outside the scope of this document.

**If everything above succeeds, the app is now deployed**

## Authors
- Morgana Spake
- Jesse Van Volkinburg
- Bonnie Wang
- Joé Jemmely

## Developer documentation
- [Awsom Scheduler Documentation](https://cf-awsom-scheduler.github.io/back-end-dev-docs/)
