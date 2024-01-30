# Social media dashboard

Hi, this project was built using an Angular front-end with ng-charts and tailwind, and a C# dotnet backend using SQL server as the database. Currently, it features randomly sample data which has been visually presented using a chart provided by the ng-charts library, a custom built progress chart and refined table data. 

### Roadmap

- [ ] Mobile/tablet friendly layout
- [ ] Form to add clients
- [ ] Form to edit client data
- [ ] Adding unique metrics for platforms

### Steps

##### 1. Clone the repositories

##### 2. Set up your database

- Edit the connection string found in ./SMDashboardApi/Data/DataContext.cs with your own unique information
- Open ./SMDashboardApi in your terminal
- Run the following commands

```
dotnet ef migrations add InitialMigration
dotnet ef database update
```

To begin seeding the database with sample data run

```
dotnet run
```

Your backend is now up and running. Now open ./social-media-dashboard and run 

```
npm start
```
</br>
Enjoy!