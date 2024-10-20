# graphql-account-service

# Banking API

## Overview

This Banking API is built using .NET and follows the principles of Clean Architecture. It provides a robust and scalable solution for managing banking operations, including account creation, balance inquiries, and fund transfers. The API leverages GraphQL for efficient data retrieval and manipulation.

## Features

- **Create Account**: Create new bank accounts with unique account numbers and customer associations.
- **Get Account**: Retrieve account details by account number.
- **Get All Accounts**: Retrieve all accounts.
- **Deposit to Account**: Deposit funds to account by account number and amount.
- **Transfer Funds**: Transfer funds between accounts securely.
- **GraphQL API**: Utilize GraphQL for flexible querying and mutations.

## Architecture

The solution is structured into four main layers:

- **Domain Layer**: Contains core entities and business logic (e.g., `Account`, `Customer`).
- **Application Layer**: Defines interfaces for services and repositories, implementing use cases.
- **Infrastructure Layer**: Provides concrete implementations for data access and external services.
- **Presentation Layer**: Exposes the GraphQL API, handling incoming requests and orchestrating responses.

## Technologies Used

- **.NET 8**
- **GraphQL with HotChocolate**
- **In-Memory Repository for Demo Purposes**
