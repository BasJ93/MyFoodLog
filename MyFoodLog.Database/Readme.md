## Creating a migration

```shell
dotnet ef migrations add FoodItemsConfiguration --startup-project MyFoodLog.API --project MyFoodLog.Database
```

## Updating the database

The application is configured to auto update the database. A manual method is provided below.

```shell
dotnet ef database update --startup-project MyFoodLog.API --project MyFoodLog.Database
```