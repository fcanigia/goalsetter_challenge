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
- Wont have dto's, just retun entities

## Busines rules 
- Vehicle: daily price > 0
- Rental: StartDate >= now
- Rental: EndDate > StartDate
- Rental: StartDate == EndDate
- Client: required client s

## Todo list
1. create entities
2. create db context
3. configure context
4. seed data
5. vehicle service (add and remove)
6. vehicle controller (add and remove)
7. check swagger configuration
8. client service
9. client controller
10. rental service
11. rental controller
12. service extension
13. migration extension
14. test rental service


## Misses
- gets should return only not removed
- custom exception middleware handler, 