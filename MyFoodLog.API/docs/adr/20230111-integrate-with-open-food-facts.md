# Integrate with Open Food Facts

- Status: accepted
- Deciders: BasJ93
- Date: 2023-01-11
- Tags: OpenFoodFacts, api

Technical Story: Integrate the Open Food Facts API

## Context and Problem Statement

To pull data about prepackaged food the Open Food Facts API can be queried, so long as any request to the API is only triggered by user interaction. The API provides full nutritional data.

## Decision Drivers

- I don't want to enter any data by hand if I can help it.
- The Open Food Facts database seems to be very well filled.

## Considered Options

- Only provide the option to enter data by hand.
- Integrate the Open Food Facts API.

## Decision Outcome

Chosen option: "Integrate the Open Food Facts API", because this allows the user to just scan a barcode and retreive all nutritional data. A backup option to just enter the data should be available.

### Positive Consequences

- Data about prepackaged food should be just a single scan await.

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
