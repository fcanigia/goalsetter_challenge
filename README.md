# Goalsetter Challenge

Create a WebAPI for a car rental project. Please use SQL Server, NET6, and Entity Framework Code First.

### Requirements:
- Add and remove vehicles.
- Add and remove clients.
- A removed vehicle should not be available for new rentals.
- Create (and cancel) rentals, only with available vehicles for the selected date range.
- Each vehicle must have a daily price that should be used to calculate the rental's final charge.
- Use the Entity Framework Seed mechanism to populate the database with some vehicles, clients, and rentals as examples.
- Don't use the repository pattern to access data.
- A rental should have (at least) the following information: client, date range, vehicle, and price.

### Notes:
- Apply all the best practices that you would for a production-ready solution.
- Provide a GitHub link to your solution. It should run without any extra steps on any machine with VS2022 and SQL Server installed.
- Apply all the business rules you think should be part of the solution, like not allowing rentals to be created in the past.

## Assumtions / implementation details
- I will use only one project, layers will be folders
- 

## Busines rules 
- 