# Goalsetter Challenge

Create a WebAPI for a car rental project. Please use SQL Server, NET6, and Entity Framework Code First.

## Run
App should run without any configuration. There could be an issue with the db connection, if so please check appsettings.json.

### Requirements:
- [X] Add and remove vehicles.
- [X] Add and remove clients.
- [X] A removed vehicle should not be available for new rentals.
- [X] Create (and cancel) rentals, only with available vehicles for the selected date range.
- [X] Each vehicle must have a daily price that should be used to calculate the rental's final charge.
- [X] Use the Entity Framework Seed mechanism to populate the database with some vehicles, clients, and rentals as examples.
- [X] Don't use the repository pattern to access data.
- [X] A rental should have (at least) the following information: client, date range, vehicle, and price.

### Notes:
- Apply all the best practices that you would for a production-ready solution.
- Provide a GitHub link to your solution. It should run without any extra steps on any machine with VS2022 and SQL Server installed.
- Apply all the business rules you think should be part of the solution, like not allowing rentals to be created in the past.

## Assumtions / implementation details
- I will use only one project, layers will be at folder level
- Wont have dto's that have the same structure as the entities
- Ideally I would not return Ids in error messages, but given that this is a challenge and I want to visually identify the Id I'll do it
- Also could have implemented a response object instead of just using throws for the validations

## Busines rules 
- Vehicle: daily price > 0
- Rental: StartDate >= now
- Rental: EndDate <> StartDate
- Rental: StartDate != EndDate
- Rental: there wont be partial price by time

## Seeded data
### Rentals (some)
| Id | ClientId | VehicleId | StartDate   | EndDate     | IsRemoved |
|----|----------|-----------|-------------|-------------|-----------|
| 4  | 1        | 1         | 2024-05-01  | 2024-05-10  | 0         |
| 5  | 2        | 6         | 2024-05-01  | 2024-05-10  | 0         |
| 6  | 3        | 3         | 2024-05-01  | 2024-05-10  | 0         |
| 7  | 1        | 1         | 2024-05-12  | 2024-05-17  | 0         |
| 8  | 2        | 6         | 2024-05-11  | 2024-05-18  | 0         |
| 9  | 3        | 3         | 2024-05-13  | 2024-05-19  | 0         |

## Misses
- custom exception middleware handler
- few tests and quite messy class