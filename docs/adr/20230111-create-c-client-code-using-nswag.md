# Create C# client code using NSwag

- Status: accepted
- Deciders: BasJ93
- Date: 2023-01-11
- Tags: NSwag, api, client

Technical Story: When creating clients for REST APIs, use NSwag to auto generate them.

## Context and Problem Statement

[Describe the context and problem statement, e.g., in free form using two to three sentences. You may want to articulate the problem in form of a question.]

## Decision Drivers

- Manually creating every API client is cumbersome.
- Most APIs provide OpenAPI specifications.

## Considered Options

- Manual implementation of every API client.
- NSwag

## Decision Outcome

Chosen option: "NSwag", because auto generating the client based on an OpenAPI spec makes it easier to implement different clients.

### Positive Consequences <!-- optional -->

- [e.g., improvement of quality attribute satisfaction, follow-up decisions required, …]
- …

### Negative Consequences <!-- optional -->

- [e.g., compromising quality attribute, follow-up decisions required, …]
- …

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

## Links

- [NSwag CommandLine interface](https://github.com/RicoSuter/NSwag/wiki/CommandLine)
