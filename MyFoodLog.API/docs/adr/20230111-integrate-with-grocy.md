# Integrate with Grocy

- Status: accepted
- Deciders: BasJ93
- Date: 2023-01-11
- Tags: Grocy, API

Technical Story: Integration with Grocy to pull recipe and mealplan data.

## Context and Problem Statement

Since I use Grocy as my recipe book, shopping list and sometimes mealplan system, I want MyFoodLog to be able to pull data from Grocy, and use this data when calculating the consumed calories, macros en micros. Using the integration with Grocy should be optional.

## Decision Drivers

- I use Grocy as my recipe book.
- I want to use Grocy for my meal planning.
- I want to use this data (mostly the calorie load for a recipe) in my calorie tracking.

## Considered Options

- Use Grocy's REST API.
- Copy the data by hand.

## Decision Outcome

Chosen option: "Use Grocy's REST API", because the API allows me to pull the data directly from Grocy. This allows me to prompt myself with the recipes that have been planned for the day when adding food to a meal, or look through the list of known recipes if nothing was found.

### Positive Consequences

- Selecting the food for a meal is easy.
- When selecting food the inventory in Grocy can be updated.

### Negative Consequences

- Grocy only provides the calories for a given meal. It does not have information about macros or micros.

## Pros and Cons of the Options <!-- optional -->

### [option 1]

[example | description | pointer to more information | …] <!-- optional -->

- Good, because [argument a]
- Good, because [argument b]
- Bad, because [argument c]
- … <!-- numbers of pros and cons can vary -->

### [option 2]

[example | description | pointer to more information | …] <!-- optional -->

- Good, because [argument a]
- Good, because [argument b]
- Bad, because [argument c]
- … <!-- numbers of pros and cons can vary -->

### [option 3]

[example | description | pointer to more information | …] <!-- optional -->

- Good, because [argument a]
- Good, because [argument b]
- Bad, because [argument c]
- … <!-- numbers of pros and cons can vary -->

## Links <!-- optional -->

- [Link type](link to adr) <!-- example: Refined by [xxx](yyyymmdd-xxx.md) -->
- … <!-- numbers of links can vary -->
